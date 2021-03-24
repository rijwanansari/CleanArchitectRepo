using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserSelfDesk.Domain.Master;

namespace UserSelfDesk.Applcaiton.Common.Interface
{
    public interface IUnityOfWork
    {
        IRepository<AppSetting> appSettingRepo { get; }

        Task<int> SaveAsync();
       // DbRawSqlQuery<T> SQLQuery<T>(string sql, params object[] parameters);
        int Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
