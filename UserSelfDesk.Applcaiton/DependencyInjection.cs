using Microsoft.Extensions.DependencyInjection;
using UserSelfDesk.Applcaiton.Master;
using UserSelfDesk.Applcaiton.UserSelfDesk;

namespace UserSelfDesk.Applcaiton
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMasterService, MasterService>();
            return services;
        }
    }
}
