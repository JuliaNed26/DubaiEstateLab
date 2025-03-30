using DubaiEstate.DAL.Models;

namespace DubaiEstate.BLL.Models;

public class ProcedureEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long TransGroupId { get; set; }
    
    public TransactionsGroupEntity TransGroup { get; set; } = null!;
}
