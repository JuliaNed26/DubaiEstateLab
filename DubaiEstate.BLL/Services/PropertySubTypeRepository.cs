using AutoMapper;
using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services;

public class PropertySubTypeRepository : IPropertySubTypeRepository
{
    private readonly IMapper _mapper;
    private readonly IPropertySubTypesDataProvider _propertySubTypesDataProvider;

    public PropertySubTypeRepository(IPropertySubTypesDataProvider propertySubTypesDataProvider, IMapper mapper)
    {
        _propertySubTypesDataProvider = propertySubTypesDataProvider;
        _mapper = mapper;
    }

    public async Task<List<PropertySubTypeEntity>> GetAllAsync()
    {
        var propertySubTypes = await _propertySubTypesDataProvider.GetAllAsync();
        return propertySubTypes.Select(_mapper.Map<PropertySubTypeEntity>).ToList();
    }

    public async Task<Result<List<PropertySubTypeEntity>>> GetByPropertyTypeAsync(long propertyTypeId)
    {
        var getPropertySubTypesResult = await _propertySubTypesDataProvider.GetByPropertyTypeAsync(propertyTypeId);
        return getPropertySubTypesResult.Match(
            propertySubTypes =>
                new Result<List<PropertySubTypeEntity>>(propertySubTypes
                    .Select(_mapper.Map<PropertySubTypeEntity>)
                    .ToList()),
            ex => new Result<List<PropertySubTypeEntity>>(ex));
    }

    public async Task<Result<PropertySubTypeEntity>> GetAsync(long id)
    {
        var getPropertySubTypeResult = await _propertySubTypesDataProvider.GetAsync(id);
        return getPropertySubTypeResult.Match(
            propertySubType => new Result<PropertySubTypeEntity>(_mapper.Map<PropertySubTypeEntity>(propertySubType)),
            ex => new Result<PropertySubTypeEntity>(ex));
    }

    public async Task<PropertySubTypeEntity> CreateAsync(PropertySubTypeEntity propertySubType)
    {
        var propertySubTypeToCreate =_mapper.Map<PropertySubType>(propertySubType); 
        var createdPropertySubType = await _propertySubTypesDataProvider.CreateAsync(propertySubTypeToCreate);
        return _mapper.Map<PropertySubTypeEntity>(createdPropertySubType); 
    }

    public async Task<Result<PropertySubTypeEntity>> UpdateAsync(PropertySubTypeEntity propertySubType)
    {
        var propertySubTypeToUpdate = _mapper.Map<PropertySubType>(propertySubType); 
        var updatePropertySubTypeResult = await _propertySubTypesDataProvider.UpdateAsync(propertySubTypeToUpdate);
        return updatePropertySubTypeResult.Match(
            updatedPropertySubType => new Result<PropertySubTypeEntity>(_mapper.Map<PropertySubTypeEntity>(updatedPropertySubType)),
            ex => new Result<PropertySubTypeEntity>(ex));
    }

    public async Task DeleteAsync(long id)
    {
        await _propertySubTypesDataProvider.DeleteAsync(id);
    }
}