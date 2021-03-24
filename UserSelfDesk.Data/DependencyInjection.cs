using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserSelfDesk.Applcaiton.Common.Interface;
using UserSelfDesk.CoreCommon.Helper;

namespace UserSelfDesk.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDeskDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UserSelfDeskDatabase")));

            services.AddScoped<IApplicationDBContext>(provider => provider.GetService<UserDeskDBContext>());
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IDateTime, MachineDateTime>();
            services.AddScoped<IConfigurationExtension, ConfigurationExtensions>();

            return services;
        }
    }
}
