using DubaiEstate.DAL.Models;

namespace DubaiEstate.BLL.Models;

public class TransactionEntity : TransactionKeysEntity
{
    public double ProcedureArea { get; set; }

    public int? ActualWorth { get; set; }

    public int? RentValue { get; set; }
}
