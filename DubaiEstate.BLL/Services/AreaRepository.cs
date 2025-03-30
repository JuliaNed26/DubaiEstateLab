using AutoMapper;
using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using DubaiEstate.DAL.DataProviders.Interfaces;
using DubaiEstate.DAL.Models;
using LanguageExt.Common;

namespace DubaiEstate.BLL.Services;

public class AreaRepository : IAreaRepository
{
    private readonly IAreasDataProvider _areasDataProvider;
    private readonly IMapper _mapper;

    public AreaRepository(IMapper mapper, IAreasDataProvider areasDataProvider)
    {
        _mapper = mapper;
        _areasDataProvider = areasDataProvider;
    }

    public async Task<List<AreaEntity>> GetAllAsync()
    {
        var areas = await _areasDataProvider.GetAllAsync();
        return areas.Select(_mapper.Map<AreaEntity>).ToList();
    }

    public async Task<Result<AreaEntity>> GetAsync(long id)
    {
        var getAreaResult = await _areasDataProvider.GetAsync(id);
        return getAreaResult.Match(
            area => new Result<AreaEntity>(_mapper.Map<AreaEntity>(area)),
            ex => new Result<AreaEntity>(ex));
    }

    public async Task<AreaEntity> CreateAsync(AreaEntity area)
    {
        var areaToCreate = _mapper.Map<Area>(area);
        var createdArticle = await _areasDataProvider.CreateAsync(areaToCreate);
        return _mapper.Map<AreaEntity>(createdArticle); 
    }

    public async Task<Result<AreaEntity>> UpdateAsync(AreaEntity area)
    {
        var areaToUpdate = _mapper.Map<Area>(area);
        var updateAreaResult = await _areasDataProvider.UpdateAsync(areaToUpdate);
        return updateAreaResult.Match(
            updatedArticle => new Result<AreaEntity>(_mapper.Map<AreaEntity>(updatedArticle)),
            ex => new Result<AreaEntity>(ex));
    }

    public async Task DeleteAsync(long id)
    {
        await _areasDataProvider.DeleteAsync(id);
    }
}