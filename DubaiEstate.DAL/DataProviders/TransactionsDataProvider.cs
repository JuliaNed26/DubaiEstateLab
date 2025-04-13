using System.Linq.Expressions;
using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Exceptions;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace DubaiEstate.DAL.DataProviders;

public class TransactionsDataProvider : ITransactionsDataProvider
{
    private readonly DubaiEstateLabContext _context;

    public TransactionsDataProvider(DubaiEstateLabContext context)
    {
        _context = context;
    }

    public async Task<Result<Transaction>> GetAsync(long id)
    {
        var foundTransaction = await _context.Transactions
            .Include(t => t.Area)
            .Include(t => t.Procedure)
            .Include(t => t.PropertySubType)
            .Include(t => t.InstanceDateNavigation)
            .FirstOrDefaultAsync(t => t.Id == id);

        return foundTransaction ?? new Result<Transaction>(
            new EntityNotFoundException($"Transaction with id '{id}' was not found"));
    }

    public async Task<PaginatedResult<Transaction>> GetAllAsync(int pageNum, int pageSize)
    {
        var query = _context.Transactions
            .Include(t => t.Procedure)
            .Include(t => t.InstanceDateNavigation)
            .Include(t => t.PropertySubType)
            .Include(t => t.Area)
            .OrderBy(t => t.InstanceDate);

        var totalCount = await query.CountAsync();
        var items = await query
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<Transaction>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNum,
            PageSize = pageSize
        };
    }

    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        _context.Entry(transaction).State = EntityState.Added;
        var foundData =
            await _context.Dates.FirstOrDefaultAsync(date => date.FullDate == transaction.InstanceDate);
        if (foundData == null)
        {
            var newDate = new Date()
            {
                FullDate = transaction.InstanceDate,
                Day = transaction.InstanceDate.Day,
                Month = transaction.InstanceDate.Month,
                Year = transaction.InstanceDate.Year,
                MonthYear = $"{transaction.InstanceDate.Month}.{transaction.InstanceDate.Year}"
            };
            await _context.Dates.AddAsync(newDate);
        }
        await _context.SaveChangesAsync();
        
        return transaction;
    }

    public async Task<Result<Transaction>> UpdateAsync(Transaction transaction)
    {
        var getResult = await GetAsync(transaction.Id);
        if (getResult.IsFaulted)
        {
            return getResult;
        }
        
        _context.Entry(transaction).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return await _context.Transactions
            .Include(t => t.Area)
            .Include(t => t.Procedure)
            .Include(t => t.PropertySubType)
            .Include(t => t.InstanceDateNavigation)
            .SingleAsync(t => t.Id == transaction.Id);
    }

    public async Task DeleteAsync(long id)
    {
        var transactionEntity = await _context.Transactions.SingleAsync(t => t.Id == id);
        _context.Transactions.Remove(transactionEntity);
        await _context.SaveChangesAsync(); 
    }
}