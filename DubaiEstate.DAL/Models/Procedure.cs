namespace DubaiEstate.DAL.Models;

public partial class Procedure
{
    public long ProcedureId { get; set; }

    public string ProcedureNameEn { get; set; } = null!;

    public long TransGroupId { get; set; }

    public virtual TransactionsGroup TransGroup { get; set; } = null!;
}
