using System;
using Tawla._360.Domain.Entities.Base;

namespace Tawla._360.Domain.Interfaces.Entities;

public interface ITranslatedEntity<TTranslation> where TTranslation:EntityTranslation
{
    public ICollection<TTranslation> Translations { get; set; }
}
