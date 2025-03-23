using DubaiEstate.DAL.DataProviders;
using DubaiEstate.DAL.DataProviders.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DubaiEstate.DAL.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseLayerServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAreasDataProvider, AreasDataProvider>();
        serviceCollection.AddScoped<IDatesDataProvider, DatesDataProvider>();
        serviceCollection.AddScoped<IProceduresDataProvider, ProceduresDataProvider>();
        serviceCollection.AddScoped<IPropertySubTypesDataProvider, PropertySubTypesDataProvider>();
        serviceCollection.AddScoped<IPropertyTypesDataProvider, PropertyTypesDataProvider>();
        serviceCollection.AddScoped<ITransactionsGroupsDataProvider, TransactionGroupsDataProvider>();
        serviceCollection.AddScoped<ITransactionsDataProvider, TransactionsDataProvider>();
        
        return serviceCollection;
    }
}