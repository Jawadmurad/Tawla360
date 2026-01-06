using Tawla._360.Application.Attributes;

namespace Tawla._360.Application.CategoryUseCases.Dto;

public record CreateCategoryDto
{
    [Translatable]
    public string Name { get; set; }   
    public string HexColor { get; set; }
    public Guid? ParentCategoryId { get; set; }
}
