using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.SupplierUseCases.Dto;

public record UpdateSupplierDto : IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
