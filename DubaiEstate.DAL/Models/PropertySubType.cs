namespace DubaiEstate.DAL.Models;

public class PropertySubType
{
    public long PropertySubTypeId { get; set; }

    public string PropertySubTypeEn { get; set; } = null!;

    public long PropertyTypeId { get; set; }

    public virtual PropertyType PropertyType { get; set; } = null!;
}
