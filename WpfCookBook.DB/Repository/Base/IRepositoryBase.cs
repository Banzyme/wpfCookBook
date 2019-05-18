﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WpfCookBook.DB.Repository.Base
{
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Provides a db interface for basic CRUD application.
        /// Uses async pattern to improve UI responsiveness.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        Task<List<T>> GetAllAsync();
        Task<T> FindItemByCondition(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindItemsByCondition(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        Task Update(T entity, long ID);
        Task Delete(T entity);
    }
}
