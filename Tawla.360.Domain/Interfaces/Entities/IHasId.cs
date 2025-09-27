using System;

namespace Tawla._360.Domain.Interfaces.Entities;

public interface IHasId
{
    public Guid Id { get; set; }
}
