using System;

namespace Tawla._360.Application.Common.Dtos.QueryRequestDtos;

public class FilterGroup
{
    public string LogicalOperator { get; set; } // "AND", "OR", "XOR"
    public List<Filter> Filters { get; set; } = new();
    public List<FilterGroup> SubGroups { get; set; } = new();
}
