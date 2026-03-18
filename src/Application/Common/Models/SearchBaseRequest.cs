namespace Elsekily.Application.Common.Models;

/// <summary>
/// Base request for paginated searches.
/// </summary>
public class SearchBaseRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
