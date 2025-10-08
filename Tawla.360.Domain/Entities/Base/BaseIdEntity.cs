using System;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.Base;

public abstract class BaseIdEntity : IBaseIdEntity
{
    public BaseIdEntity()
    {
        this.CreatedDate = DateTime.UtcNow;
    }
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
}
