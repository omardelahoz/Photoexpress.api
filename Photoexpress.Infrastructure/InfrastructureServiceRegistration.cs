using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Domain.Entities;
using Photoexpress.Infrastructure.Database;
using Photoexpress.Infrastructure.Managers.Database;

namespace Photoexpress.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<PhotoexpressContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PhotoexpressConn"))
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IParameterRepository, ParameterManager>();

            return services;
        }

    }
}
