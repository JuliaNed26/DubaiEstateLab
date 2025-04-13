using DubaiEstate.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DubaiEstate.BLL.Services;
// Services/MdxQueryService.cs
using Microsoft.AnalysisServices.AdomdClient;
using System.Collections.Generic;
using System.Data;

public class MdxQueryService : IMdxQueryService
{
    private readonly string _connectionString;

    public MdxQueryService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("OLAPConnection")!;
    }

    public List<Dictionary<string, object>> ExecuteMdxQuery(string mdxQuery)
    {
        var results = new List<Dictionary<string, object>>();

        using (var connection = new AdomdConnection(_connectionString))
        {
            connection.Open();
            using (var command = new AdomdCommand(mdxQuery, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    // Get column names
                    var columns = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columns.Add(reader.GetName(i));
                    }

                    // Read data
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[columns[i]] = reader.GetValue(i);
                        }
                        results.Add(row);
                    }
                }
            }
        }

        return results;
    }
}