namespace DubaiEstate.DAL.Models;

public class TransactionsGroup
{
    public long TransGroupId { get; set; }

    public string TransGroupEn { get; set; } = null!;

    public virtual ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
}
