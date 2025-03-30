using AutoMapper;
using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services;

public class DateRepository : IDateRepository
{
    private readonly IMapper _mapper;
    private readonly IDatesDataProvider _datesDataProvider;

    public DateRepository(IMapper mapper, IDatesDataProvider datesDataProvider)
    {
        _mapper = mapper;
        _datesDataProvider = datesDataProvider;
    }

    public async Task<Result<DateEntity>> GetAsync(DateOnly date)
    {
        var getdateResult = await _datesDataProvider.GetAsync(date);
        return getdateResult.Match(
            result => new Result<DateEntity>(_mapper.Map<DateEntity>(result)),
            ex => new Result<DateEntity>(ex));
    }

    public async Task<DateEntity> CreateAsync(DateEntity date)
    {
        var dateToCreate = _mapper.Map<Date>(date);
        var createdDate = await _datesDataProvider.CreateAsync(dateToCreate);
        return _mapper.Map<DateEntity>(createdDate); 
    }

    public async Task<Result<DateEntity>> UpdateAsync(DateEntity date)
    {
        var dateToUpdate = _mapper.Map<Date>(date);
        var updateDateResult = await _datesDataProvider.UpdateAsync(dateToUpdate);
        return updateDateResult.Match(
            updatedDate => new Result<DateEntity>(_mapper.Map<DateEntity>(updatedDate)),
            ex => new Result<DateEntity>(ex));
    }

    public async Task DeleteAsync(DateOnly date)
    {
        await _datesDataProvider.DeleteAsync(date);
    }
}