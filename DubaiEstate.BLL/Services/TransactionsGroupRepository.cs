using AutoMapper;
using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services;

public class TransactionsGroupRepository : ITransactionsGroupRepository
{
    private readonly IMapper _mapper;
    private readonly ITransactionsGroupsDataProvider _transactionsGroupsDataProvider;

    public TransactionsGroupRepository(IMapper mapper, ITransactionsGroupsDataProvider transactionsGroupsDataProvider)
    {
        _mapper = mapper;
        _transactionsGroupsDataProvider = transactionsGroupsDataProvider;
    }

    public async Task<List<TransactionsGroupEntity>> GetAllAsync()
    {
        var transactionsGroups = await _transactionsGroupsDataProvider.GetAllAsync();
        return transactionsGroups.Select(_mapper.Map<TransactionsGroupEntity>).ToList();
    }

    public async Task<Result<TransactionsGroupEntity>> GetAsync(long id)
    {
        var getTransactionsGroupResult = await _transactionsGroupsDataProvider.GetAsync(id);
        return getTransactionsGroupResult.Match(
            transactionsGroup => new Result<TransactionsGroupEntity>(_mapper.Map<TransactionsGroupEntity>(transactionsGroup)),
            ex => new Result<TransactionsGroupEntity>(ex));
    }

    public async Task<TransactionsGroupEntity> CreateAsync(TransactionsGroupEntity transactionsGroup)
    {
        var transactionsGroupToCreate = _mapper.Map<TransactionsGroup>(transactionsGroup);
        var createdTransactionsGroup = await _transactionsGroupsDataProvider.CreateAsync(transactionsGroupToCreate);
        return _mapper.Map<TransactionsGroupEntity>(createdTransactionsGroup); 
    }

    public async Task<Result<TransactionsGroupEntity>> UpdateAsync(TransactionsGroupEntity transactionsGroup)
    {
        var transactionsGroupToUpdate = _mapper.Map<TransactionsGroup>(transactionsGroup);
        var updateTransactionsGroupResult = await _transactionsGroupsDataProvider.UpdateAsync(transactionsGroupToUpdate);
        return updateTransactionsGroupResult.Match(
            updatedTransactionsGroup => new Result<TransactionsGroupEntity>(_mapper.Map<TransactionsGroupEntity>(updatedTransactionsGroup)),
            ex => new Result<TransactionsGroupEntity>(ex));
    }

    public async Task DeleteAsync(long id)
    {
        await _transactionsGroupsDataProvider.DeleteAsync(id);
    }
}