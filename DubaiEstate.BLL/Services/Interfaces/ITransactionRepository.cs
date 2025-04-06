using DubaiEstate.BLL.Models;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services.Interfaces;

public interface ITransactionRepository
{
    Task<Result<TransactionEntity>> GetAsync(long id);
    
    Task<PaginatedResult<TransactionEntity>> GetAllAsync(int pageNum, int pageSize);
    
    Task<TransactionEntity> CreateAsync(TransactionEntity transaction);
    
    Task<Result<TransactionEntity>> UpdateAsync(TransactionEntity transaction);
    
    Task DeleteAsync(long id);
}