using AutoMapper;
using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services;

public class PropertyTypeRepository : IPropertyTypeRepository
{
    private readonly IMapper _mapper;
    private readonly IPropertyTypesDataProvider _propertyTypesDataProvider;

    public PropertyTypeRepository(IMapper mapper, IPropertyTypesDataProvider propertyTypesDataProvider)
    {
        _mapper = mapper;
        _propertyTypesDataProvider = propertyTypesDataProvider;
    }

    public async Task<List<PropertyTypeEntity>> GetAllAsync()
    {
        var propertyTypes = await _propertyTypesDataProvider.GetAllAsync();
        return propertyTypes.Select(_mapper.Map<PropertyTypeEntity>).ToList();
    }

    public async Task<Result<PropertyTypeEntity>> GetAsync(long id)
    {
        var getPropertyTypeResult = await _propertyTypesDataProvider.GetAsync(id);
        return getPropertyTypeResult.Match(
            propertyType => new Result<PropertyTypeEntity>(_mapper.Map<PropertyTypeEntity>(propertyType)),
            ex => new Result<PropertyTypeEntity>(ex));
    }

    public async Task<PropertyTypeEntity> CreateAsync(PropertyTypeEntity propertyType)
    {
        var propertyTypeToCreate =_mapper.Map<PropertyType>(propertyType); 
        var createdArticle = await _propertyTypesDataProvider.CreateAsync(propertyTypeToCreate);
        return _mapper.Map<PropertyTypeEntity>(createdArticle);
    }

    public async Task<Result<PropertyTypeEntity>> UpdateAsync(PropertyTypeEntity propertyType)
    {
        var propertyTypeToUpdate =_mapper.Map<PropertyType>(propertyType); 
        var updatePropertyTypeResult = await _propertyTypesDataProvider.UpdateAsync(propertyTypeToUpdate);
        return updatePropertyTypeResult.Match(
            updatedArticle => new Result<PropertyTypeEntity>(_mapper.Map<PropertyTypeEntity>(updatedArticle)),
            ex => new Result<PropertyTypeEntity>(ex));
    }

    public async Task DeleteAsync(long id)
    {
        await _propertyTypesDataProvider.DeleteAsync(id);
    }
}