using Tawla._360.Application.Attributes;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.CategoryUseCases.Dto;

public record CategoryListDto:IHasId
{
    public Guid Id {get;set;}
    [Translatable]
    public string Name { get; set; }
    public string HexColor { get; set; }
}
