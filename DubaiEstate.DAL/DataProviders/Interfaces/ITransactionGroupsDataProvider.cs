using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.DAL.DataProviders.Interfaces;

public interface ITransactionsGroupsDataProvider
{
    Task<List<TransactionsGroup>> GetAllAsync();
    
    Task<Result<TransactionsGroup>> GetAsync(long id);
    
    Task<TransactionsGroup> CreateAsync(TransactionsGroup transactionsGroup);
    
    Task<Result<TransactionsGroup>> UpdateAsync(TransactionsGroup transactionsGroup);
    
    Task DeleteAsync(long id);
}