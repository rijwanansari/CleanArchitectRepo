using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserSelfDesk.Applcaiton.Common.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Add(IList<T> entities);
        void Add(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IList<T> entities);
        void Update(IEnumerable<T> entities);
        void AddOrUpdate(Expression<Func<T, object>> exp, T entity);
        void AddOrUpdate(T entity);
        void AddOrUpdate(IEnumerable<T> entities);
        Task<bool> Delete(object id);
        Task<bool> Delete(T entity);
        Task<bool> Delete(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        Task<T> Get(object id);
        Task<T> Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
        void Save();
        void SaveAsync();

        Task<int> Count(Expression<Func<T, bool>> where);
        Task<int> Count();
        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        #endregion
    }
}
