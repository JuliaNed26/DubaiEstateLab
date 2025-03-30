using DubaiEstate.BLL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services.Interfaces;

public interface ITransactionRepository
{
    Task<Result<TransactionEntity>> GetAsync(TransactionKeysEntity transactionKeys);
    
    Task<List<TransactionEntity>> GetAllAsync();
    
    Task<TransactionEntity> CreateAsync(TransactionEntity transaction);
    
    Task<Result<TransactionEntity>> UpdateAsync(TransactionEntity transaction);
    
    Task DeleteAsync(TransactionKeysEntity transactionKeys);
}