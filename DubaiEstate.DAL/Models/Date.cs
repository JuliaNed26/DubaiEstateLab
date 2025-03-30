namespace DubaiEstate.DAL.Models;

public class Date
{
    public DateOnly FullDate { get; set; }

    public int Day { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public string MonthYear { get; set; } = null!;
}
