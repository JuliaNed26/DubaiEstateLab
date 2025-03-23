using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Exceptions;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace DubaiEstate.DAL.DataProviders;

public class AreasDataProvider : IAreasDataProvider
{
    private readonly DubaiEstateLabContext _context;

    public AreasDataProvider(DubaiEstateLabContext context)
    {
        _context = context;
    }

    public async Task<List<Area>> GetAllAsync()
    {
        return await _context.Areas.ToListAsync();
    }

    public async Task<Result<Area>> GetAsync(long id)
    {
        var foundArea = await _context.Areas.FindAsync(id);
        return foundArea ?? new Result<Area>(
            new EntityNotFoundException($"Area with id '{id}' was not found"));
    }

    public async Task<Area> CreateAsync(Area area)
    {
        _context.Entry(area).State = EntityState.Added;
        await _context.SaveChangesAsync();
        
        return area;
    }

    public async Task<Result<Area>> UpdateAsync(Area area)
    {
        var getResult = await GetAsync(area.AreaId);
        if (getResult.IsFaulted)
        {
            return getResult;
        }
        
        _context.Entry(area).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return await _context.Areas.SingleAsync(x => x.AreaId == area.AreaId);
    }

    public async Task DeleteAsync(long id)
    {
        var foundArticle = await _context.Areas.FindAsync(id);
        if (foundArticle == null)
        {
            return;
        }
        _context.Entry(foundArticle).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
}