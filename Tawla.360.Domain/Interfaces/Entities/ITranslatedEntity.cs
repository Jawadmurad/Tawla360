using System;
using Tawla._360.Domain.Entities.Base;

namespace Tawla._360.Domain.Interfaces.Entities;

public interface ITranslatedEntity<TEntity> where TEntity:Translation
{
    public ICollection<TEntity> Translation { get; set; }
}
