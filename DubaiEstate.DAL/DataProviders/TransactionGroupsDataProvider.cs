using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Exceptions;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace DubaiEstate.DAL.DataProviders;

public class TransactionGroupsDataProvider : ITransactionsGroupsDataProvider
{
    private readonly DubaiEstateLabContext _context;

    public TransactionGroupsDataProvider(DubaiEstateLabContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionsGroup>> GetAllAsync()
    {
        return await _context.TransactionsGroups.ToListAsync();
    }

    public async Task<Result<TransactionsGroup>> GetAsync(long id)
    {
        var foundTransactionGroup = await _context.TransactionsGroups.FindAsync(id);
        return foundTransactionGroup ?? new Result<TransactionsGroup>(
            new EntityNotFoundException($"Transaction group with id '{id}' was not found"));
    }

    public async Task<TransactionsGroup> CreateAsync(TransactionsGroup transactionsGroup)
    {
        _context.Entry(transactionsGroup).State = EntityState.Added;
        await _context.SaveChangesAsync();
        
        return transactionsGroup;
    }

    public async Task<Result<TransactionsGroup>> UpdateAsync(TransactionsGroup transactionsGroup)
    {
        var getResult = await GetAsync(transactionsGroup.TransGroupId);
        if (getResult.IsFaulted)
        {
            return getResult;
        }
        
        _context.Entry(transactionsGroup).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return await _context.TransactionsGroups.SingleAsync(x => x.TransGroupId == transactionsGroup.TransGroupId);
    }

    public async Task DeleteAsync(long id)
    {
        var foundTransactionGroup = await _context.TransactionsGroups.FindAsync(id);
        if (foundTransactionGroup == null)
        {
            return;
        }
        _context.Entry(foundTransactionGroup).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
}