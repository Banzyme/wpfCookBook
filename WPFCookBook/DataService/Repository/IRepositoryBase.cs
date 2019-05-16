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
        Task<T> FindItemByCondition(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindItemsByCondition(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        Task Update(T entity, long ID);
        Task Delete(T entity);
        void Save();
    }
}
