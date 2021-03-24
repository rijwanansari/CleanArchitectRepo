using System.Threading.Tasks;
using UserSelfDesk.Applcaiton.Common.Model;

namespace UserSelfDesk.Applcaiton.UserSelfDesk
{
    public class UserResetRequestService : IUserResetRequestService
    {
        #region properties

        #endregion
        #region Ctor
        public UserResetRequestService()
        { 
        
        }
        #endregion
        public Task<ResponseModel> VerifyUserByUserAccount(string userAccount)
        {
            throw new System.NotImplementedException();
        }
    }
}
