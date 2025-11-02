using System;
using System.ComponentModel.DataAnnotations;

namespace Tawla._360.Domain.Entities.Base;

public class Translation
{
    public string PropertyName { get; set; }
    public string Value { get; set; }
    public string LanguageCode { get; set; }
}
