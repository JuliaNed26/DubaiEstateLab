namespace DubaiEstate.BLL.Services.Interfaces;

public interface IMdxQueryService
{
    List<Dictionary<string, object>> ExecuteMdxQuery(string mdxQuery);
}