namespace DubaiEstate.BLL.Models;

public class DateEntity
{
    public DateOnly Date { get; set; }

    public int Day { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public string MonthYear { get; set; } = null!;
}
