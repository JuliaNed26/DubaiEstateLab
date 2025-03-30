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

    public async Task<Result<Transaction>> GetAsync(TransactionKeys transactionKeys)
    {
        var foundTransaction = await _context.Transactions
            .Where(GetKeyEqualityExpression(transactionKeys))
            .FirstOrDefaultAsync();

        return foundTransaction ?? new Result<Transaction>(
            new EntityNotFoundException($"Transaction with Procedure id " +
                                        $"'{transactionKeys.ProcedureId}'" +
                                        $" Area id '{transactionKeys.AreaId}'" +
                                        $" Date {transactionKeys.InstanceDate}" +
                                        $" Property sub type id '{transactionKeys.PropertySubTypeId}' was not found"));
    }

    public async Task<List<Transaction>> GetAllAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        _context.Entry(transaction).State = EntityState.Added;
        await _context.SaveChangesAsync();
        
        return transaction;
    }

    public async Task<Result<Transaction>> UpdateAsync(Transaction transaction)
    {
        var getResult = await GetAsync(transaction);
        if (getResult.IsFaulted)
        {
            return getResult;
        }
        
        _context.Entry(transaction).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return await _context.Transactions.SingleAsync(GetKeyEqualityExpression(transaction));
    }

    public Task DeleteAsync(TransactionKeys transactionKeys)
    {
        throw new NotImplementedException();
    }

    private static Expression<Func<Transaction, bool>> GetKeyEqualityExpression(TransactionKeys transactionKeys)
    {
        return tr => tr.ProcedureId == transactionKeys.ProcedureId
                     && tr.AreaId == transactionKeys.AreaId
                     && tr.InstanceDate == transactionKeys.InstanceDate
                     && tr.PropertySubTypeId == transactionKeys.PropertySubTypeId;
    }
}