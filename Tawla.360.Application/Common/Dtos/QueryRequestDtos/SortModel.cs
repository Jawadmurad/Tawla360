using Tawla._360.Application.Common.Enums;

namespace Tawla._360.Application.Common.Dtos.QueryRequestDtos;

public class SortModel
{
    public string Field { get; set; }
    public SortDirection SortDirection { get; set; }
}