using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using System.Reflection;
using TFGDevopsApp.Services;
using TFGDevopsApp1.Common.Helpers;
using TFGDevopsApp1.Core.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Mantis.Issues;
using TFGDevopsApp1.Infraestructure.Repository;
using TFGDevopsApp1.Interfaces;
using TFGDevopsApp1.Mediator.Command.Mantis;
using TFGDevopsApp1.Mediator.Queries.Mantis.Issues;
using TFGDevopsApp1.Services;

namespace TFGDevopsApp1.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddRadzenComponents();
            services.AddAntDesign();
            services.AddAutoMapper(typeof(Program));
            services.AddSingleton<ExecutableService>();
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
