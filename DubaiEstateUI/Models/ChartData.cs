namespace DubaiEstateUI.Models;
public class ChartData
{
    public List<string> Labels { get; set; }
    public ChartDataset Dataset { get; set; }
    public List<double> Percentages { get; set; }
}

public class ChartDataset
{
    public string Label { get; set; }
    public List<int> Data { get; set; }
    public List<string> BackgroundColors { get; set; }
    public int BorderWidth { get; set; }
}
