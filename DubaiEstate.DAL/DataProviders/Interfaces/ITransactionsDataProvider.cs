using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.DAL.DataProviders.Interfaces;

public interface ITransactionsDataProvider
{
    Task<Result<Transaction>> GetAsync(long id);
    
    Task<PaginatedResult<Transaction>> GetAllAsync(int pageNum, int pageSize);
    
    Task<Transaction> CreateAsync(Transaction transaction);
    
    Task<Result<Transaction>> UpdateAsync(Transaction transaction);
    
    Task DeleteAsync(long id);
}