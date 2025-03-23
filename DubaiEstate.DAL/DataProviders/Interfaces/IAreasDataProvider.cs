using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.DAL.DataProviders.Interfaces;

public interface IAreasDataProvider
{
    Task<List<Area>> GetAllAsync();
    
    Task<Result<Area>> GetAsync(long id);
    
    Task<Area> CreateAsync(Area area);
    
    Task<Result<Area>> UpdateAsync(Area area);
    
    Task DeleteAsync(long id);
}