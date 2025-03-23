namespace DubaiEstate.DAL.Models;

public partial class Transaction
{
    public long ProcedureId { get; set; }

    public DateOnly InstanceDate { get; set; }

    public long PropertySubTypeId { get; set; }

    public long AreaId { get; set; }

    public double ProcedureArea { get; set; }

    public int? ActualWorth { get; set; }

    public int? RentValue { get; set; }

    public virtual Date InstanceDateNavigation { get; set; } = null!;
}
