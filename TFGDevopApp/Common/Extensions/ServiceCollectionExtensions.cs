using Microsoft.Extensions.DependencyInjection;
using Radzen;
using System.Reflection;
using TFGDevopsApp.Core.Helpers;
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
            services.AddAutoMapper(typeof(Program));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IPlasticServices, PlasticServices>();
            services.AddScoped<IFolderTreeService, FolderTreeService>();
            services.AddScoped<IFolderTreeRepository, FolderTreeRepository>();
            services.AddScoped<IMantisServices, MantisServices>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
