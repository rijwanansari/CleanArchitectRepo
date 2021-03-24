using UserSelfDesk.Applcaiton.UserSelfDesk.Dto;

namespace UserSelfDesk.Applcaiton.Common.Interface
{
    public interface IConfigurationExtension
    {
        string GetKeyValue(string key);
        //ActiveDirectoryCredentialModel ActiveDirectoryCredentials();
    }
}
