using ARQUICAPAS.Infrastructure.Persistences.Contexts;
using ARQUICAPAS.Infrastructure.Persistences.Interfaces;
using ARQUICAPAS.Infrastructure.Persistences.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ARQUICAPAS.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
            var assembly = typeof(CRUDContext).Assembly.FullName;
            services.AddDbContext<CRUDContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;

        }
    }
}
