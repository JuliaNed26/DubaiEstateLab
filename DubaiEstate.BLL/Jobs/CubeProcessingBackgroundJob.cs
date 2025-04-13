using DubaiEstate.BLL.Services.Interfaces;
using Microsoft.Extensions.Hosting;

namespace DubaiEstate.BLL.Jobs;

public class CubeProcessingBackgroundJob : BackgroundService 
{
    private readonly PeriodicTimer _timer = new (TimeSpan.FromMinutes(1));
    private readonly ICubeProcessingService _cubeProcessingService;

    public CubeProcessingBackgroundJob(ICubeProcessingService cubeProcessingService)
    {
        _cubeProcessingService = cubeProcessingService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _timer.WaitForNextTickAsync(stoppingToken)
               && !stoppingToken.IsCancellationRequested)
        {
            _cubeProcessingService.ProcessCube();
        }
    }
}