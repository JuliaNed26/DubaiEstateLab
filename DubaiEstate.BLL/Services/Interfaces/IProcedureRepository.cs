using DubaiEstate.BLL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services.Interfaces;

public interface IProcedureRepository
{
    Task<List<ProcedureEntity>> GetAllAsync();
    
    Task<Result<ProcedureEntity>> GetAsync(long id);
    
    Task<ProcedureEntity> CreateAsync(ProcedureEntity procedure);
    
    Task<Result<ProcedureEntity>> UpdateAsync(ProcedureEntity procedure);
    
    Task DeleteAsync(long id);
}