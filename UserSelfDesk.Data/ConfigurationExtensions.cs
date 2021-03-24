using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using UserSelfDesk.Applcaiton.Common.Interface;
using UserSelfDesk.Applcaiton.UserSelfDesk.Dto;

namespace UserSelfDesk.Data
{
    public class ConfigurationExtensions : IConfigurationExtension
    {
        private IConfiguration _configuration;
        public ConfigurationExtensions()
        {
            _configuration = GetConfiguration();
        }

        //public ActiveDirectoryCredentialModel ActiveDirectoryCredentials()
        //{
        //    var  activeDirectoryConfig = _configuration.GetSection("ActiveDirectoryCredentials");
        //    ActiveDirectoryCredentialModel activeDirectoryCredentialModel = new ActiveDirectoryCredentialModel();
        //    activeDirectoryCredentialModel.ServerUrl = activeDirectoryConfig["Server"].ToString();
        //    activeDirectoryCredentialModel.AdminUserName = activeDirectoryConfig["AdminUser"].ToString();
        //    activeDirectoryCredentialModel.Password = activeDirectoryConfig["Password"];

        //    return activeDirectoryCredentialModel;
        //}
        private IConfiguration GetConfiguration()
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}AppWeb", Path.DirectorySeparatorChar);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            return configuration;
        }
        public string GetKeyValue(string key)
        {
            string result = _configuration.GetSection("appSettings")["key"].ToString();
            return result;
        }
    }
}
