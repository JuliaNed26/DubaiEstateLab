using AutoMapper;
using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using DubaiEstate.DAL.DataProviders.Interfaces;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services;

// ToDo: to be implemented
public class TransactionRepository : ITransactionRepository
{
    private readonly IMapper _mapper;
    private readonly ITransactionsDataProvider _transactionsDataProvider;

    public TransactionRepository(IMapper mapper, ITransactionsDataProvider transactionsDataProvider)
    {
        _mapper = mapper;
        _transactionsDataProvider = transactionsDataProvider;
    }

    public Task<Result<TransactionEntity>> GetAsync(TransactionKeysEntity transactionKeys)
    {
        throw new NotImplementedException();
    }

    public Task<List<TransactionEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TransactionEntity> CreateAsync(TransactionEntity transaction)
    {
        throw new NotImplementedException();
    }

    public Task<Result<TransactionEntity>> UpdateAsync(TransactionEntity transaction)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TransactionKeysEntity transactionKeys)
    {
        throw new NotImplementedException();
    }
}