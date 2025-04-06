using AutoMapper;
using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services;

public class TransactionRepository : ITransactionRepository
{
    private readonly IMapper _mapper;
    private readonly ITransactionsDataProvider _transactionsDataProvider;

    public TransactionRepository(IMapper mapper, ITransactionsDataProvider transactionsDataProvider)
    {
        _mapper = mapper;
        _transactionsDataProvider = transactionsDataProvider;
    }

    public async Task<Result<TransactionEntity>> GetAsync(long id)
    {
        var getTransactionResult =
            await _transactionsDataProvider.GetAsync(id);
        return getTransactionResult.Match(
            transaction => new Result<TransactionEntity>(_mapper.Map<TransactionEntity>(transaction)),
            ex => new Result<TransactionEntity>(ex));
    }

    public async Task<PaginatedResult<TransactionEntity>> GetAllAsync(int pageNum, int pageSize)
    {
        var transactions = await _transactionsDataProvider.GetAllAsync(pageNum, pageSize);
        return _mapper.Map<PaginatedResult<TransactionEntity>>(transactions);
    }

    public async Task<TransactionEntity> CreateAsync(TransactionEntity transaction)
    {
        var transactionToCreate =_mapper.Map<Transaction>(transaction); 
        var createdTransaction = await _transactionsDataProvider.CreateAsync(transactionToCreate);
        return _mapper.Map<TransactionEntity>(createdTransaction);
    }

    public async Task<Result<TransactionEntity>> UpdateAsync(TransactionEntity transaction)
    { 
        var transactionToUpdate =_mapper.Map<Transaction>(transaction); 
        var updateTransactionResult = await _transactionsDataProvider.UpdateAsync(transactionToUpdate);
        return updateTransactionResult.Match(
            updatedTransaction => new Result<TransactionEntity>(_mapper.Map<TransactionEntity>(updatedTransaction)),
            ex => new Result<TransactionEntity>(ex));
    }

    public async Task DeleteAsync(long id)
    {
        await _transactionsDataProvider.DeleteAsync(id);
    }
}