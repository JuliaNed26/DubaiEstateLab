using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.DAL.DataProviders.Interfaces;

public interface IProceduresDataProvider
{
    Task<List<Procedure>> GetAllAsync();
    
    Task<Result<Procedure>> GetAsync(long id);
    
    Task<Procedure> CreateAsync(Procedure procedure);
    
    Task<Result<Procedure>> UpdateAsync(Procedure procedure);
    
    Task DeleteAsync(long id);
}