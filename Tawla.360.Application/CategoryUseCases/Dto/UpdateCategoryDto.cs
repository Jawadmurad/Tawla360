using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.CategoryUseCases.Dto;

public class UpdateCategoryDto : IHasId
{
    public Guid Id { get; set; }
}
