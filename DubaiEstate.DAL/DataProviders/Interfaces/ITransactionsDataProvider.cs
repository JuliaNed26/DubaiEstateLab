using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.DAL.DataProviders.Interfaces;

public interface ITransactionsDataProvider
{
    Task<Result<Transaction>> GetAsync(TransactionKeys transactionKeys);
    
    Task<List<Transaction>> GetAllAsync();
    
    Task<Transaction> CreateAsync(Transaction transaction);
    
    Task<Result<Transaction>> UpdateAsync(Transaction transaction);
    
    Task DeleteAsync(TransactionKeys transactionKeys);
}