using Tawla._360.Application.Attributes;

namespace Tawla._360.Application.CategoryUseCases.Dto;

public record class LiteCategoryDto
{
    public Guid Id { get; set; }
    [Translatable]
    public string Name { get; set; }   
}
