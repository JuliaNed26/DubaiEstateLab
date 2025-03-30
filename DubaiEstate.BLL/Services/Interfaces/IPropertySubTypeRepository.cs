using DubaiEstate.BLL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services.Interfaces;

public interface IPropertySubTypeRepository
{
    Task<List<PropertySubTypeEntity>> GetAllAsync();
    
    Task<Result<List<PropertySubTypeEntity>>> GetByPropertyTypeAsync(long propertyTypeId);
    
    Task<Result<PropertySubTypeEntity>> GetAsync(long id);
    
    Task<PropertySubTypeEntity> CreateAsync(PropertySubTypeEntity propertySubType);
    
    Task<Result<PropertySubTypeEntity>> UpdateAsync(PropertySubTypeEntity propertySubType);
    
    Task DeleteAsync(long id);
}