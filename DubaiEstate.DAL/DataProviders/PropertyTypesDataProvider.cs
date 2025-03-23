using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Exceptions;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace DubaiEstate.DAL.DataProviders;

public class PropertyTypesDataProvider : IPropertyTypesDataProvider
{
    private readonly DubaiEstateLabContext _context;

    public PropertyTypesDataProvider(DubaiEstateLabContext context)
    {
        _context = context;
    }

    public async Task<List<PropertyType>> GetAllAsync()
    {
        return await _context.PropertyTypes.ToListAsync();
    }

    public async Task<Result<PropertyType>> GetAsync(long id)
    {
        var foundPropertyType = await _context.PropertyTypes.FindAsync(id);
        return foundPropertyType ?? new Result<PropertyType>(
            new EntityNotFoundException($"Property type with id '{id}' was not found"));
    }

    public async Task<PropertyType> CreateAsync(PropertyType propertyType)
    {
        _context.Entry(propertyType).State = EntityState.Added;
        await _context.SaveChangesAsync();
        
        return propertyType;
    }

    public async Task<Result<PropertyType>> UpdateAsync(PropertyType propertyType)
    {
        var getResult = await GetAsync(propertyType.PropertyTypeId);
        if (getResult.IsFaulted)
        {
            return getResult;
        }
        
        _context.Entry(propertyType).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return await _context.PropertyTypes.SingleAsync(x => x.PropertyTypeId == propertyType.PropertyTypeId);
    }

    public async Task DeleteAsync(long id)
    {
        var foundPropertyType = await _context.PropertyTypes.FindAsync(id);
        if (foundPropertyType == null)
        {
            return;
        }
        _context.Entry(foundPropertyType).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
}