using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; 
using Proyecto_Expertos.Application.Interfaces;
using Proyecto_Expertos.Infrastructure.Data;            
using Proyecto_Expertos.Infrastructure.Repositories;

namespace Proyecto_Expertos.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PPEDBContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IPPERepository, PPERepository>();

            return services;
        }
    }
}