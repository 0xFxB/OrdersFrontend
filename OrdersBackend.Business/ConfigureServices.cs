using Microsoft.Extensions.DependencyInjection;

namespace OrdersBackend.Business;

public static class ConfigureService
{
    public static void InitBusiness(this IServiceCollection service)
    {
        service.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(ConfigureService).Assembly));
    }
}
