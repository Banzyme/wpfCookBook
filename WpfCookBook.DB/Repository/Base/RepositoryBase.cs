using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCookBook.DB.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDBContext _db { get; private set; }
        public RepositoryBase(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task Create(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {

            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<T> FindItemByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression).First();
        }

        public IEnumerable<T> FindItemsByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task Update(T entity, long ID)
        {
            T existing = _db.Set<T>().Find(ID);
            _db.Entry(existing).CurrentValues.SetValues(entity);
            await _db.SaveChangesAsync();
        }
    }
}
