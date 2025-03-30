using AutoMapper;
using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services;

public class ProcedureRepository : IProcedureRepository
{
    private readonly IMapper _mapper;
    private readonly IProceduresDataProvider _proceduresDataProvider;

    public ProcedureRepository(IMapper mapper, IProceduresDataProvider proceduresDataProvider)
    {
        _mapper = mapper;
        _proceduresDataProvider = proceduresDataProvider;
    }

    public async Task<List<ProcedureEntity>> GetAllAsync()
    {
        var procedures = await _proceduresDataProvider.GetAllAsync();
        return procedures.Select(_mapper.Map<ProcedureEntity>).ToList();
    }

    public async Task<Result<ProcedureEntity>> GetAsync(long id)
    {
        var getProcedureResult = await _proceduresDataProvider.GetAsync(id);
        return getProcedureResult.Match(
            procedure => new Result<ProcedureEntity>(_mapper.Map<ProcedureEntity>(procedure)),
            ex => new Result<ProcedureEntity>(ex));
    }

    public async Task<ProcedureEntity> CreateAsync(ProcedureEntity procedure)
    {
        var procedureToCreate = _mapper.Map<Procedure>(procedure); 
        var createdProcedure = await _proceduresDataProvider.CreateAsync(procedureToCreate);
        return _mapper.Map<ProcedureEntity>(createdProcedure);
    }

    public async Task<Result<ProcedureEntity>> UpdateAsync(ProcedureEntity procedure)
    {
        var procedureToUpdate = _mapper.Map<Procedure>(procedure); 
        var updateProcedureResult = await _proceduresDataProvider.UpdateAsync(procedureToUpdate);
        return updateProcedureResult.Match(
            updatedProcedure => new Result<ProcedureEntity>(_mapper.Map<ProcedureEntity>(updatedProcedure)),
            ex => new Result<ProcedureEntity>(ex));
    }

    public async Task DeleteAsync(long id)
    {
        await _proceduresDataProvider.DeleteAsync(id);
    }
}