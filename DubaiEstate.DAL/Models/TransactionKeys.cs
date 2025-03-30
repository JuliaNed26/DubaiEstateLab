namespace DubaiEstate.DAL.Models;

public class TransactionKeys
{
    public long ProcedureId { get; set; }

    public DateOnly InstanceDate { get; set; }

    public long PropertySubTypeId { get; set; }

    public long AreaId { get; set; }
}