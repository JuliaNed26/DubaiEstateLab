using DubaiEstate.BLL.Mapping;
using DubaiEstate.BLL.Services;
using DubaiEstate.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DubaiEstate.BLL.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogicLayerServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(MapperProfile).Assembly);

        serviceCollection.AddScoped<IAreaRepository, AreaRepository>();
        serviceCollection.AddScoped<IDateRepository, DateRepository>();
        serviceCollection.AddScoped<IProcedureRepository, ProcedureRepository>();
        serviceCollection.AddScoped<IPropertySubTypeRepository, PropertySubTypeRepository>();
        serviceCollection.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
        serviceCollection.AddScoped<ITransactionsGroupRepository, TransactionsGroupRepository>();
        serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();
        
        return serviceCollection;
    }
}