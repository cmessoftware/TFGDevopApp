using Microsoft.Extensions.DependencyInjection;
using Radzen;
using TFGDevopsApp.Infraestructure.Repository;
using TFGDevopsApp.Services;

namespace TFGDevopsApp.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddRadzenComponents();
            services.AddAntDesign();
            services.AddScoped<IPlasticServices, PlasticServices>();
            services.AddScoped<IFolderTreeService, FolderTreeService>();
            services.AddScoped<IFolderTreeRepository, FolderTreeRepository>();
            services.AddScoped<IMantisServices, MantisServices>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
