using System;

namespace Tawla._360.Domain.Interfaces.Entities;

public interface IBaseIdEntity: IHasId
{
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
}
