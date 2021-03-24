using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserSelfDesk.Applcaiton.Common.Interface;
using UserSelfDesk.Domain.Master;

namespace UserSelfDesk.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        #region Properties
        private readonly UserDeskDBContext context;
        IDbContextTransaction dbContextTransaction;
        private IRepository<AppSetting> AppSettingRepo;
        #endregion
        #region Ctor
        public UnityOfWork(UserDeskDBContext context)
        {
            this.context = context;
        }
        #endregion
        #region Methods

        #region Repository
        public IRepository<AppSetting> appSettingRepo
        {
            get
            {
                if (this.AppSettingRepo == null)
                    this.AppSettingRepo = new EfRepository<AppSetting>(context);
                return AppSettingRepo;
            }
        }
        #endregion



        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        public void BeginTransaction()
        {
            dbContextTransaction = context.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Commit();
            }
        }
        public void RollbackTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Rollback();
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
