using System.Text.Json;
using DubaiEstate.BLL.Services.Interfaces;
using DubaiEstateUI.Models;

namespace DubaiEstateUI.Controllers;
// Controllers/VisualizationController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class VisualizationController : Controller
{
    private readonly IMdxQueryService _mdxService;

    public VisualizationController(IMdxQueryService mdxService)
    {
        _mdxService = mdxService;
    }

    public IActionResult TransactionPercentage()
    {
        string mdxQuery = @"
        WITH 
        MEMBER [Measures].[Transaction Percentage] AS 
          ([Measures].[Transactions Count] / 
           ([Measures].[Transactions Count], [Procedure].[Trans Group En].[All])),
          FORMAT_STRING = '0.00%' 

        SELECT 
          NON EMPTY { [Measures].[Transaction Percentage] } ON COLUMNS,
          NON EMPTY { 
            [Procedure].[Trans Group En].&[Gifts],
            [Procedure].[Trans Group En].&[Mortgages],
            [Procedure].[Trans Group En].&[Sales]
          } ON ROWS 
        FROM [Dubai Estate Lab]";

        var results = _mdxService.ExecuteMdxQuery(mdxQuery);

        // Prepare data for the view
        var labels = new List<string>();
        var data = new List<double>();
        var backgroundColors = new List<string>();

        foreach (var row in results)
        {
            // Get the transaction type (row label)
            var rowKey = row.Keys.First(k => k != "[Measures].[Transaction Percentage]");
            labels.Add(row[rowKey].ToString()!);

            // Get the percentage value
            if (row["[Measures].[Transaction Percentage]"] is double percentage)
            {
                data.Add(percentage * 100); // Convert to percentage (0-100)
            }

            // Add a color (you can customize this)
            backgroundColors.Add(GetRandomColor());
        }

        ViewBag.ChartData = new
        {
            Labels = labels,
            Data = data,
            BackgroundColors = backgroundColors
        };

        return View();
    }

    // Controllers/VisualizationController.cs (add this method to your existing controller)
    public IActionResult AverageWorthOverYears()
    {
        string mdxQuery = @"
    WITH 
    MEMBER [Measures].[Avg Worth] AS 
      AVG(
        EXISTING [Date].[Year].MEMBERS,
        [Measures].[Actual Worth]
      ),
      FORMAT_STRING = '#,##0.00'

    SELECT 
      NON EMPTY { [Measures].[Avg Worth] } ON COLUMNS,
      NON EMPTY 
        FILTER(
          [Date].[Year].MEMBERS,
          ([Measures].[Actual Worth]) > 0
        ) ON ROWS
    FROM [Dubai Estate Lab]";

        var results = _mdxService.ExecuteMdxQuery(mdxQuery);

        // Prepare data for the view
        var labels = new List<string>();
        var data = new List<double>();
        var backgroundColors = new List<string>();
        var borderColors = new List<string>();

        foreach (var row in results[1..])
        {
            // Get the year (row label)
            var rowKey = row.Keys.First(k => k != "[Measures].[Avg Worth]");
            labels.Add(row[rowKey].ToString()!);

            // Get the average worth value
            if (row["[Measures].[Avg Worth]"] is double avgWorth)
            {
                data.Add(avgWorth);
            }

            // Add colors
            backgroundColors.Add(GetRandomColor());
            borderColors.Add(GetRandomColor());
        }

        ViewBag.ChartData = new
        {
            Labels = labels,
            Data = data,
            BackgroundColors = backgroundColors,
            BorderColors = borderColors
        };

        return View();
    }

    // Controllers/VisualizationController.cs (add this method to your existing controller)
    public IActionResult TransactionsRadar()
    {
        string mdxQuery = @"
    SELECT 
      NON EMPTY { [Measures].[Transactions Count] } ON COLUMNS,
      NON EMPTY { 
        [Procedure].[Trans Group En].&[Sales],
        [Procedure].[Trans Group En].[All]
      } ON ROWS
    FROM [Dubai Estate Lab]";

        var results = _mdxService.ExecuteMdxQuery(mdxQuery);

        // Prepare data for the view
        var labels = new List<string>();
        var salesData = new List<int>();
        var allData = new List<int>();

        foreach (var row in results)
        {
            // Get the transaction type (row label)
            var rowKey = row.Keys.First(k => k != "[Measures].[Transactions Count]");
            var label = row[rowKey] != null ? "Sales" : "All Transactions";
            labels.Add(label);

            // Get the transactions count value
            if (row["[Measures].[Transactions Count]"] is int count)
            {
                if (label == "Sales")
                {
                    salesData.Add(count);
                }
                else
                {
                    allData.Add(count);
                }
            }
        }

        ViewBag.ChartData = new
        {
            Labels = labels,
            SalesData = salesData,
            AllData = allData,
            BackgroundColors = new List<string>
            {
                GetRandomColor(),
                GetRandomColor()
            },
            BorderColors = new List<string>
            {
                GetRandomColor(),
                GetRandomColor()
            }
        };

        return View();
    }

    // Controllers/VisualizationController.cs
    public IActionResult ProcedureAreaSparkline()
    {
        string mdxQuery = @"
    SELECT 
      NON EMPTY { [Measures].[Procedure Area] } ON COLUMNS,
      NON EMPTY { [Date].[Year].MEMBERS } ON ROWS
    FROM [Dubai Estate Lab]";

        var results = _mdxService.ExecuteMdxQuery(mdxQuery);

        // Prepare data for the view
        var labels = new List<string>();
        var data = new List<double>();

        foreach (var row in results[1..])
        {
            // Get the year (row label)
            var rowKey = row.Keys.First(k => k != "[Measures].[Procedure Area]");
            labels.Add(row[rowKey].ToString()!);

            // Get the procedure area value
            if (row["[Measures].[Procedure Area]"] is double area)
            {
                data.Add(area);
            }
            else
            {
                data.Add(0); // Default value if null
            }
        }

        ViewBag.ChartData = new
        {
            Labels = labels,
            Data = data
        };

        return View();
    }

    public IActionResult PropertyTypeDistribution()
    {
        string mdxQuery = @"
    WITH 
    MEMBER [Measures].[Transaction Percentage] AS 
      ([Measures].[Transactions Count] / ([Measures].[Transactions Count], [Property Sub Type].[Property Type En].[All])),
      FORMAT_STRING = '0.00%'

    SELECT 
      NON EMPTY { [Measures].[Transactions Count], [Measures].[Transaction Percentage] } ON COLUMNS,
      NON EMPTY { [Property Sub Type].[Property Type En].MEMBERS } ON ROWS
    FROM [Dubai Estate Lab]";

        var results = _mdxService.ExecuteMdxQuery(mdxQuery);

        // Prepare chart data
        var chartData = new ChartData
        {
            Labels = new List<string>(),
            Dataset = new ChartDataset
            {
                Label = "Transactions",
                Data = new List<int>(),
                BackgroundColors = new List<string>
                {
                    GetRandomColor(),
                    GetRandomColor(),
                    GetRandomColor(),
                    GetRandomColor()
                },
                BorderWidth = 1
            },
            Percentages = new List<double>()
        };

        foreach (var row in results[1..])
        {
            var propertyType = row.First().Value.ToString()!;

            chartData.Labels.Add(propertyType);
            chartData.Dataset.Data.Add(row["[Measures].[Transactions Count]"] is int count ? count : 0);
            chartData.Percentages.Add(row["[Measures].[Transaction Percentage]"] is double percent ? percent * 100 : 0);
        }

        ViewBag.TotalCount = chartData.Dataset.Data.Sum().ToString("N0");
        ViewBag.ChartData = chartData;
        var a = JsonSerializer.Serialize(chartData);

        return View();
    }

    private string GetRandomColor()
    {
        var random = new Random();
        return $"rgba({random.Next(0, 255)}, {random.Next(0, 255)}, {random.Next(0, 255)}, 0.7)";
    }
}