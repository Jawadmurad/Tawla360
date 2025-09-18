using System;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.Base;

public class BaseNamedEntity : BaseIdEntity, IHasName
{
    public string Name { get; set; }
}
