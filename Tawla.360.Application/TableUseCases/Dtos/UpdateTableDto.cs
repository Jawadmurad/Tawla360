using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.TableUseCases.Dtos;

public record class UpdateTableDto : IHasId
{
    public Guid Id {get;set;}
}
