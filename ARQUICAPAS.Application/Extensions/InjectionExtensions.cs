using ARQUICAPAS.Application.Interfaces;
using ARQUICAPAS.Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ARQUICAPAS.Application.Extensions
{
    public static class InjectionExtensions
    {
        //[Obsolete]
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IEncargadoApplication, EncargadoApplication>();
            services.AddScoped<IUserApplication, UserApplication>();

            return services;
        }
    }
}
