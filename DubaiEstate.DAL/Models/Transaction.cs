namespace DubaiEstate.DAL.Models;

public class Transaction
{
    public long Id { get; set; }
    
    public double ProcedureArea { get; set; }

    public int? ActualWorth { get; set; }

    public int? RentValue { get; set; }
    
    public long ProcedureId { get; set; }

    public DateOnly InstanceDate { get; set; }

    public long PropertySubTypeId { get; set; }

    public long AreaId { get; set; }

    public virtual Date InstanceDateNavigation { get; set; } = null!;
    
    public virtual Area Area { get; set; }
    
    public virtual Procedure Procedure { get; set; } = null!;

    public virtual PropertySubType PropertySubType { get; set; }
}
