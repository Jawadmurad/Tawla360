using Tawla._360.Application.ModifierUseCases.Dto;

namespace Tawla._360.Application.ModifierGroupUserCase.Dtos;

public record ModifierOptionDto
{
    public Guid Id { get; set; }
    public ModifierLiteDto Modifier { get; set; }
    public int? DisplayOrder { get; set; }
    public List<ModifierOptionPriceDto> ModifierOptionPrices { get; set; }

}
