using System.Threading.Tasks;
using UserSelfDesk.Applcaiton.Common.Model;
using UserSelfDesk.Applcaiton.Master.Dto;

namespace UserSelfDesk.Applcaiton.Master
{
    public interface IMasterService
    {
        Task<ResponseModel> Upsert(ReferenceMasterViewModel referenceMasterViewModel);
       
        
        #region AppSetting
        Task<ResponseModel> UpsertAppSetting(AppSettingViewModel appSettingViewModel);
        Task<ResponseModel> GetAppSettingByKey(string referenceKey);
        Task<ResponseModel> GetAllAppSetting();
        #endregion

    }
}
