using UserSelfDesk.Domain.UserManagement;

namespace UserSelfDesk.Applcaiton.Common.Mappings
{
    public static class ManualViewMapping
    {
        #region "ADUser"
        public static AdUser ConvertToModel(this System.DirectoryServices.AccountManagement.UserPrincipal userPrincipal)
        {
            if (userPrincipal != null)
            {
                AdUser adUser = new AdUser
                {
                    AccountExpirationDate = userPrincipal.AccountExpirationDate,
                AccountLockoutTime = userPrincipal.AccountLockoutTime,
                BadLogonCount = userPrincipal.BadLogonCount,
                Description = userPrincipal.Description,
                DisplayName = userPrincipal.DisplayName,
                DistinguishedName = userPrincipal.DistinguishedName,
                EmailAddress = userPrincipal.EmailAddress,
                EmployeeId = userPrincipal.EmployeeId,
                Enabled = userPrincipal.Enabled,
                GivenName = userPrincipal.GivenName,
                Guid = userPrincipal.Guid,
                HomeDirectory = userPrincipal.HomeDirectory,
                HomeDrive = userPrincipal.HomeDrive,
                LastBadPasswordAttempt = userPrincipal.LastBadPasswordAttempt,
                LastLogon = userPrincipal.LastLogon,
                LastPasswordSet = userPrincipal.LastPasswordSet,
                MiddleName = userPrincipal.MiddleName,
                Name = userPrincipal.Name,
                PasswordNeverExpires = userPrincipal.PasswordNeverExpires,
                PasswordNotRequired = userPrincipal.PasswordNotRequired,
                SamAccountName = userPrincipal.SamAccountName,
                ScriptPath = userPrincipal.ScriptPath,
                Surname = userPrincipal.Surname,
                UserCannotChangePassword = userPrincipal.UserCannotChangePassword,
                UserPrincipalName = userPrincipal.UserPrincipalName,
                VoiceTelephoneNumber = userPrincipal.VoiceTelephoneNumber,
                DelegationPermitted = userPrincipal.DelegationPermitted,
                StructuralObjectClass = userPrincipal.StructuralObjectClass
            };
                return adUser;
            }
            else
                return null;
        }

        #endregion
    }
}
