using Microsoft.Extensions.DependencyInjection;

namespace DubaiEstate.BLL.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogicLayerServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}