namespace DubaiEstate.DAL.Models;

public class Transaction : TransactionKeys
{
    public double ProcedureArea { get; set; }

    public int? ActualWorth { get; set; }

    public int? RentValue { get; set; }

    public virtual Date InstanceDateNavigation { get; set; } = null!;
    
    public virtual Area Area { get; set; }
    
    public virtual Procedure Procedure { get; set; } = null!;

    public virtual PropertySubType PropertySubType { get; set; }
}
