using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WPFCookBook.DataService.Repository
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        T FindItemByCondition(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindItemsByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity, long ID);
        void Delete(T entity);
        void Save();
    }
}
