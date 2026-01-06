using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.TableUseCases.Dtos;

public record class TableDto : IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TableStatus Status { get; set; }
}
