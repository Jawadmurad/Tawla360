using System;

namespace Tawla._360.Domain.Interfaces.Entities;

public interface IHasId
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
}
