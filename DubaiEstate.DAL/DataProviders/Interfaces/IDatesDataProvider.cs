using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.DAL.DataProviders.Interfaces;

public interface IDatesDataProvider
{
    Task<Result<Date>> GetAsync(DateOnly date);
    
    Task<Date> CreateAsync(Date date);
    
    Task<Result<Date>> UpdateAsync(Date date);
    
    Task DeleteAsync(DateOnly date);
}