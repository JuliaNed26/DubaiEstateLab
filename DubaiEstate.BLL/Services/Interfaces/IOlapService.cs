using System.Data;

namespace DubaiEstate.BLL.Services.Interfaces;

public interface IOlapService
{
    DataTable ExecuteMdxQuery(string mdxQuery);
}