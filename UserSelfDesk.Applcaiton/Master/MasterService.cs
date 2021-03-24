using System.Threading.Tasks;
using UserSelfDesk.Applcaiton.Common;
using UserSelfDesk.Applcaiton.Common.Error;
using UserSelfDesk.Applcaiton.Common.Interface;
using UserSelfDesk.Applcaiton.Common.Mappings;
using UserSelfDesk.Applcaiton.Common.Model;
using UserSelfDesk.Applcaiton.Master.Dto;
using UserSelfDesk.Domain.Master;

namespace UserSelfDesk.Applcaiton.Master
{
    public class MasterService : IMasterService
    {
        private readonly IUnityOfWork _unityOfWork;
        public MasterService(IUnityOfWork unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }
        public async Task<ResponseModel> Upsert(ReferenceMasterViewModel referenceMasterViewModel)
        {
            try
            {
                return ResponseModel.SuccessResponse("", null);

            }
            catch (System.Exception)
            {

                throw;
            }
        }



        #region AppSetting
        public async Task<ResponseModel> UpsertAppSetting(AppSettingViewModel appSettingViewModel)
        {
            try
            {
                if (string.IsNullOrEmpty(appSettingViewModel.type))
                    appSettingViewModel.type = "Text";

                if (appSettingViewModel.id > 0)
                    _unityOfWork.appSettingRepo.Update(appSettingViewModel.MapTo<AppSettingViewModel, AppSetting>());
                else
                    _unityOfWork.appSettingRepo.Add(appSettingViewModel.MapTo<AppSettingViewModel, AppSetting>());

                await _unityOfWork.SaveAsync();
                return ResponseModel.SuccessResponse(GlobalDecleration._savedSuccesfully, null);
            }
            catch (System.Exception ex)
            {
                Print(nameof(UpsertAppSetting), ex.Message);
                return ResponseModel.FailureResponse(GlobalDecleration._internalServerError, null);
            }
        }
        public async Task<ResponseModel> GetAllAppSetting()
        {
            try
            {
                var appSettings = _unityOfWork.appSettingRepo.GetAll();
                return ResponseModel.SuccessResponse(GlobalDecleration._savedSuccesfully, appSettings);
            }
            catch (System.Exception ex)
            {

                Print(nameof(UpsertAppSetting), ex.Message);
                return ResponseModel.FailureResponse(GlobalDecleration._internalServerError, null);
            }
        }

        public Task<ResponseModel> GetAppSettingByKey(string referenceKey)
        {
            throw new System.NotImplementedException();
        }
        #endregion


        #region "Error"
        private void Print(string method
           , string msg)
        {
            ErrorLogs.PrintError("MasterService"
                , method
                , msg);
        }
        #endregion
    }
}
