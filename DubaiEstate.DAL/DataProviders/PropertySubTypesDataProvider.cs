using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Exceptions;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace DubaiEstate.DAL.DataProviders;

public class PropertySubTypesDataProvider : IPropertySubTypesDataProvider
{
    private readonly DubaiEstateLabContext _context;

    public PropertySubTypesDataProvider(DubaiEstateLabContext context)
    {
        _context = context;
    }

    public async Task<List<PropertySubType>> GetAllAsync()
    {
        return await _context.PropertySubTypes.ToListAsync();
    }

    public async Task<Result<List<PropertySubType>>> GetByPropertyTypeAsync(long propertyTypeId)
    {
        var subTypesByPropertyId = await _context.PropertySubTypes
            .Where(x => x.PropertyTypeId == propertyTypeId)
            .ToListAsync();
        return subTypesByPropertyId;
    }

    public async Task<Result<PropertySubType>> GetAsync(long id)
    {
        var foundPropertySubType = await _context.PropertySubTypes.FindAsync(id);
        return foundPropertySubType ?? new Result<PropertySubType>(
            new EntityNotFoundException($"Property sub type with id '{id}' was not found"));
    }

    public async Task<PropertySubType> CreateAsync(PropertySubType propertySubType)
    {
        _context.Entry(propertySubType).State = EntityState.Added;
        await _context.SaveChangesAsync();
        
        return propertySubType;
    }

    public async Task<Result<PropertySubType>> UpdateAsync(PropertySubType propertySubType)
    {
        var getResult = await GetAsync(propertySubType.PropertySubTypeId);
        if (getResult.IsFaulted)
        {
            return getResult;
        }
        
        _context.Entry(propertySubType).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return await _context.PropertySubTypes.SingleAsync(x => x.PropertySubTypeId == propertySubType.PropertySubTypeId);
    }

    public async Task DeleteAsync(long id)
    {
        var foundPropertySubType = await _context.PropertySubTypes.FindAsync(id);
        if (foundPropertySubType == null)
        {
            return;
        }
        _context.Entry(foundPropertySubType).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
}