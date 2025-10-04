using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.BranchUseCases.Dtos;

public record class UpdateBranchDto : IHasId
{
    public Guid Id { get; set; }
}
