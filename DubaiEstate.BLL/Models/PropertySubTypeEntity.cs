using DubaiEstate.DAL.Models;

namespace DubaiEstate.BLL.Models;

public class PropertySubTypeEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long PropertyTypeId { get; set; }
    
    public PropertyTypeEntity PropertyType { get; set; } = null!;
}
