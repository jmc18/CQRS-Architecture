using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("ApplicationDBContext"),
                _ => _.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName))
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging()
            );

            #region Repository

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(CustomerRepository<>));

            #endregion

            return services;
        }
    }
}
