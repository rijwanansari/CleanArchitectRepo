using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserSelfDesk.Applcaiton.Common.Interface;

namespace UserSelfDesk.Data
{
   public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Properties
        private readonly UserDeskDBContext _context;

        protected DbSet<TEntity> _entities;
        #endregion

        #region Ctor

        public EfRepository(UserDeskDBContext context)
        {
            _context = context;
        }

        #endregion
        #region Utilities

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Error message</returns>
        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            //rollback entity changes
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException)
                    {
                        // ignored
                    }
                });
            }

            try
            {
                _context.SaveChanges();
                return exception.ToString();
            }
            catch (Exception ex)
            {
                //if after the rollback of changes the context is still not saving,
                //return the full text of the exception that occurred when saving
                return ex.ToString();
            }
        }

        #endregion

        #region Methods

        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                Entities.AddAsync(entity);

            }
            catch (DbUpdateException exception)
            {
                //foreach (var validationErrors in exception.EntityValidationErrors)
                //{
                //    foreach (var validationError in validationErrors.ValidationErrors)
                //    {
                //        Trace.TraceInformation("Property: {0} Error: {1}",
                //                                validationError.PropertyName,
                //                                validationError.ErrorMessage);
                //    }
                //}
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }

        }
        public virtual void Add(IList<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            foreach (var item in entities)
                Add(item);

        }
        public virtual void Add(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            try
            {
                Entities.AddRangeAsync(entities);
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
            catch (Exception ex)
            {
                //Trace.TraceInformation("Source: {0} Error: {1}",
                //                                ex.Source,
                //                                ex.Message);
                throw ex;
            }

        }
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                Entities.Update(entity);
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual void Update(IList<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            try
            {
                foreach (var item in entities)
                    Update(item);
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual void Update(IEnumerable<TEntity> entities)
        {

            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.UpdateRange(entities);
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual void AddOrUpdate(Expression<Func<TEntity, object>> exp, TEntity entity)
        {
           //_entities.AddOrUpdate(exp, entity);
        }
        public virtual void AddOrUpdate(TEntity entity)
        {
            // _entities.AddOrUpdate(entity);
        }

        public virtual void AddOrUpdate(IEnumerable<TEntity> entities)
        {

            //try
            //{
            //    foreach (T entity in entities)
            //        dbSet.AddOrUpdate(entity);
            //}
            //catch (Exception ex)
            //{
            //    var error = string.Format("Source: {0} Error: {1}", ex.Source, ex.Message);
            //    throw ex;

            //}
        }
        public virtual async Task<bool> Delete(object id)
        {
            try
            {
                var entity =await Entities.FindAsync(id);
                if (entity == null)
                    return false;

                Entities.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<bool> Delete(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                var entities = Entities.Where(where);
                Entities.RemoveRange(entities);
                return true;
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task<bool> Delete(TEntity entity)
        {
            try
            {
                if (entity == null)
                    return false;

                Entities.Remove(entity);
                return true;
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }        
        public virtual async Task<TEntity> Get(object id)
        {
            try
            {
                return await Entities.FindAsync(id);
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> where)
        {
            return await Entities.FirstOrDefaultAsync(where);
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            try
            {
                return Entities;
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return Entities.Where(where);
        }
        public virtual void Save()
        {
            _context.SaveChanges();
        }
        public virtual void SaveAsync()
        {
            _context.SaveChangesAsync();
        }
        public virtual async Task<int> Count()
        {
            return await Entities.CountAsync();

        }
        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> where)
        {
            return await Entities.CountAsync(where);

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<TEntity> Table => Entities;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();

                return _entities;
            }
        }

        #endregion
    }
}
