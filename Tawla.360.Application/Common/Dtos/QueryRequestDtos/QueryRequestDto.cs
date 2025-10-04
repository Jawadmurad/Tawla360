using System;
using Tawla._360.Shared;

namespace Tawla._360.Application.Common.Dtos.QueryRequestDtos;

public class QueryRequestDto
{
    /// <summary>
    /// The filtering conditions for the query.
    /// Supports multiple filters combined using logical operators (AND/OR).
    /// </summary>
    public FilterGroup FilterGroup { get; set; }

    /// <summary>
    /// The pagination settings to control how many records are returned per page.
    /// </summary>
    public PagingRequestDto Paging { get; set; }

    /// <summary>
    /// The sorting options for the query.
    /// Supports multiple sorting fields.
    /// </summary>
    public IEnumerable<SortModel> Sort { get; set; }
    public object BuildFilter { get; internal set; }
}
