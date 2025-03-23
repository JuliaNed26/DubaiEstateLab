using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Exceptions;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace DubaiEstate.DAL.DataProviders;

public class ProceduresDataProvider : IProceduresDataProvider
{
    private readonly DubaiEstateLabContext _context;

    public ProceduresDataProvider(DubaiEstateLabContext context)
    {
        _context = context;
    }

    public async Task<List<Procedure>> GetAllAsync()
    {
        return await _context.Procedures.ToListAsync();
    }

    public async Task<Result<Procedure>> GetAsync(long id)
    {
        var foundProcedure = await _context.Procedures.FindAsync(id);
        return foundProcedure ?? new Result<Procedure>(
            new EntityNotFoundException($"Procedure with id '{id}' was not found"));
    }

    public async Task<Procedure> CreateAsync(Procedure procedure)
    {
        _context.Entry(procedure).State = EntityState.Added;
        await _context.SaveChangesAsync();
        
        return procedure;
    }

    public async Task<Result<Procedure>> UpdateAsync(Procedure procedure)
    {
        var getResult = await GetAsync(procedure.ProcedureId);
        if (getResult.IsFaulted)
        {
            return getResult;
        }
        
        _context.Entry(procedure).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return await _context.Procedures.SingleAsync(x => x.ProcedureId == procedure.ProcedureId);
    }

    public async Task DeleteAsync(long id)
    {
        var foundProcedure = await _context.Procedures.FindAsync(id);
        if (foundProcedure == null)
        {
            return;
        }
        _context.Entry(foundProcedure).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
}