using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.DAL.DataProviders.Interfaces;

public interface ITransactionsDataProvider
{
    Task<List<Transaction>> GetAllAsync();
    
    Task<Transaction> CreateAsync(Transaction transaction);
}