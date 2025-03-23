namespace DubaiEstate.DAL.Models;

public partial class PropertyType
{
    public long PropertyTypeId { get; set; }

    public string PropertyTypeEn { get; set; } = null!;

    public virtual ICollection<PropertySubType> PropertySubTypes { get; set; } = new List<PropertySubType>();
}
