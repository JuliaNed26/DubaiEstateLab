namespace DubaiEstate.BLL.Models;

public class TransactionsGroupEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual IEnumerable<ProcedureEntity> Procedures { get; set; }
}
