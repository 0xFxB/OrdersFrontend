using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersBackend.Shared.Entities;
using OrdersBackend.Shared.Interfaces.Repositories;

namespace OrdersBackend.Data;

public static class ConfigureService
{
    public static void InitSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        InitDatabase(services, configuration);
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }

    private static void InitDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrdersDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SQLSERVER"));

        }, ServiceLifetime.Singleton);
    }
}
