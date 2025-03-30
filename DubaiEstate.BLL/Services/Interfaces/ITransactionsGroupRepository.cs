using DubaiEstate.BLL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services.Interfaces;

public interface ITransactionsGroupRepository
{
    Task<List<TransactionsGroupEntity>> GetAllAsync();
    
    Task<Result<TransactionsGroupEntity>> GetAsync(long id);
    
    Task<TransactionsGroupEntity> CreateAsync(TransactionsGroupEntity transactionsGroup);
    
    Task<Result<TransactionsGroupEntity>> UpdateAsync(TransactionsGroupEntity transactionsGroup);
    
    Task DeleteAsync(long id);
}