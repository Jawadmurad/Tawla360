using System;

namespace Tawla._360.Domain.Interfaces.Entities;

public interface IHasBranch : IBaseIdEntity
{
    public Guid BranchId { get; set; }
}
