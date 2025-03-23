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
}