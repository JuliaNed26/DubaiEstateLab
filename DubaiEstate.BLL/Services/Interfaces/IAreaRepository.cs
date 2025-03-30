using DubaiEstate.BLL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services.Interfaces;

public interface IAreaRepository
{
    Task<List<AreaEntity>> GetAllAsync();
    
    Task<Result<AreaEntity>> GetAsync(long id);
    
    Task<AreaEntity> CreateAsync(AreaEntity area);
    
    Task<Result<AreaEntity>> UpdateAsync(AreaEntity area);
    
    Task DeleteAsync(long id);
}