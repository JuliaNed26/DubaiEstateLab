using Microsoft.AnalysisServices.AdomdClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using DubaiEstate.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DubaiEstate.BLL.Services;

public class OlapService : IOlapService
{
    private readonly string _connectionString;

    public OlapService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("OLAPConnection")!;
    }

    public DataTable ExecuteMdxQuery(string mdxQuery)
    { 
        var result = new DataTable();
    
        using (var conn = new AdomdConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = mdxQuery;
            
                // Use DataAdapter instead of direct reader
                using (var adapter = new AdomdDataAdapter(cmd))
                {
                    // Configure adapter settings
                    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                
                    // Clear existing table structure
                    result.Clear();
                    result.Constraints.Clear();
                
                    // Fill data without constraints
                    adapter.Fill(result);
                }
            }
        }
    
        // Explicitly allow nulls for all columns
        foreach (DataColumn col in result.Columns)
        {
            col.AllowDBNull = true;
        }
    
        return result;
    }
}