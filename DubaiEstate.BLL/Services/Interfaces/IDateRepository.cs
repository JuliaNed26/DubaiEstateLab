using DubaiEstate.BLL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services.Interfaces;

public interface IDateRepository
{
    Task<Result<DateEntity>> GetAsync(DateOnly date);
    
    Task<DateEntity> CreateAsync(DateEntity date);
    
    Task<Result<DateEntity>> UpdateAsync(DateEntity date);
    
    Task DeleteAsync(DateOnly date);
}