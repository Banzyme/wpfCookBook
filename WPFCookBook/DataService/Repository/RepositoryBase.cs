using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCookBook.DataService.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDBContext _db { get; set; }

        public RepositoryBase(ApplicationDBContext db)
        {
            _db = db;
        }

        public void Create(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChangesAsync();
        }

        public void Delete(T entity)
        {

            _db.Set<T>().Remove(entity);
            _db.SaveChangesAsync();
        }

        public T FindItemByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression).First<T>();
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

        public void Update(T entity, long ID)
        {
            T existing = _db.Set<T>().Find(ID);
            _db.Entry(existing).CurrentValues.SetValues(entity);
            _db.SaveChangesAsync();
        }
    }
}
