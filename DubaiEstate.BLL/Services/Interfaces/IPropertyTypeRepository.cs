using DubaiEstate.BLL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services.Interfaces;

public interface IPropertyTypeRepository
{
    Task<List<PropertyTypeEntity>> GetAllAsync();
    
    Task<Result<PropertyTypeEntity>> GetAsync(long id);
    
    Task<PropertyTypeEntity> CreateAsync(PropertyTypeEntity propertyType);
    
    Task<Result<PropertyTypeEntity>> UpdateAsync(PropertyTypeEntity propertyType);
    
    Task DeleteAsync(long id);
}