using DubaiEstate.BLL.Services.Interfaces;
using Microsoft.AnalysisServices;
using Microsoft.Extensions.Configuration;

namespace DubaiEstate.BLL.Services;

public class CubeProcessingService : ICubeProcessingService
{
    private readonly string _cubeConnectionString;
    private const string DatabaseName = "DubaiEstateLab";
    private const string CubeName = "Dubai Estate Lab";
    
    public CubeProcessingService(IConfiguration configuration)
    {
        _cubeConnectionString = configuration.GetConnectionString("OLAPConnection")!;    
    }
    
    public void ProcessCube()
    {
        Server server = new Server();
        server.Connect(_cubeConnectionString);

        Database database = server.Databases.FindByName(DatabaseName);
        Cube cube = database.Cubes.FindByName(CubeName);

        cube.Process(ProcessType.ProcessFull);
    }
}