using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Exceptions;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace DubaiEstate.DAL.DataProviders;

public class DatesDataProvider : IDatesDataProvider
{
    private readonly DubaiEstateLabContext _context;

    public DatesDataProvider(DubaiEstateLabContext context)
    {
        _context = context;
    }

    public async Task<Result<Date>> GetAsync(DateOnly date)
    {
        var foundDate = await _context.Dates.FindAsync(date);
        return foundDate ?? new Result<Date>(
            new EntityNotFoundException($"Date with id '{date}' was not found"));
    }

    public async Task<Date> CreateAsync(Date date)
    {
        _context.Entry(date).State = EntityState.Added;
        await _context.SaveChangesAsync();
        
        return date;
    }

    public async Task<Result<Date>> UpdateAsync(Date date)
    {
        var getResult = await GetAsync(date.FullDate);
        if (getResult.IsFaulted)
        {
            return getResult;
        }
        
        _context.Entry(date).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return await _context.Dates.SingleAsync(x => x.FullDate == date.FullDate);
    }

    public async Task DeleteAsync(DateOnly date)
    {
        var foundDate = await _context.Dates.FindAsync(date);
        if (foundDate == null)
        {
            return;
        }
        _context.Entry(foundDate).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
}