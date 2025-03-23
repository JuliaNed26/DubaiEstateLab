using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.DAL.DataProviders.Interfaces;

public interface IPropertyTypesDataProvider
{
    Task<List<PropertyType>> GetAllAsync();
    
    Task<Result<PropertyType>> GetAsync(long id);
    
    Task<PropertyType> CreateAsync(PropertyType propertyType);
    
    Task<Result<PropertyType>> UpdateAsync(PropertyType propertyType);
    
    Task DeleteAsync(long id);
}