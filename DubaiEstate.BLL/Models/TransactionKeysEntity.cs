namespace DubaiEstate.BLL.Models;

public class TransactionKeysEntity
{
    public long ProcedureId { get; set; }

    public DateOnly InstanceDate { get; set; }

    public long PropertySubTypeId { get; set; }

    public long AreaId { get; set; }
}