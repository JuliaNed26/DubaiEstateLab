using DubaiEstate.DAL.Models;

namespace DubaiEstate.BLL.Models;

public class TransactionEntity 
{
    public long Id { get; set; }
    
    public double ProcedureArea { get; set; }

    public int? ActualWorth { get; set; }

    public int? RentValue { get; set; }
    
    public long ProcedureId { get; set; }

    public DateOnly InstanceDate { get; set; }

    public long PropertySubTypeId { get; set; }

    public long AreaId { get; set; }
    
    public ProcedureEntity? Procedure { get; set; }
    
    public DateEntity? Date { get; set; }
    
    public PropertySubTypeEntity? PropertySubType { get; set; }
    
    public AreaEntity? Area { get; set; }
}
