using System.Threading.Tasks;
using UserSelfDesk.Applcaiton.Common.Model;

namespace UserSelfDesk.Applcaiton.UserSelfDesk
{
    public interface IUserResetRequestService
    {
        Task<ResponseModel> VerifyUserByUserAccount(string userAccount);
    }
}
