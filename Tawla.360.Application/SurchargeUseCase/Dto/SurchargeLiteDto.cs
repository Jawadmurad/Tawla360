using Tawla._360.Application.Attributes;

namespace Tawla._360.Application.SurchargeUseCase.Dto;

public record class SurchargeLiteDto
{
    public Guid Id { get; set; }
    [Translatable]
    public string Name { get; set; }
}
