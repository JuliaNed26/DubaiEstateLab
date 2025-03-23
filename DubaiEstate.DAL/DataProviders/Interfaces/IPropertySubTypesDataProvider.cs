using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.DAL.DataProviders.Interfaces;

public interface IPropertySubTypesDataProvider
{
    Task<List<PropertySubType>> GetAllAsync();
    
    Task<Result<List<PropertySubType>>> GetByPropertyTypeAsync(long propertyTypeId);
    
    Task<Result<PropertySubType>> GetAsync(long id);
    
    Task<PropertySubType> CreateAsync(PropertySubType propertySubType);
    
    Task<Result<PropertySubType>> UpdateAsync(PropertySubType propertySubType);
    
    Task DeleteAsync(long id);
}