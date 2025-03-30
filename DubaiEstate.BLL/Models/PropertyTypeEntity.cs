namespace DubaiEstate.BLL.Models;

public class PropertyTypeEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public IEnumerable<PropertySubTypeEntity> PropertySubTypes { get; set; }
}
