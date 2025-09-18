using System;

namespace Tawla._360.Domain.Interfaces.Entities;

public interface IHasName:IHasId
{
    public string Name { get; set; }
}
