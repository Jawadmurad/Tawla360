using System;
using Tawla._360.Domain.Entities.Base;

namespace Tawla._360.Domain.Entities.Settings;

public class Discount:BaseBranchEntity
{
    public string Name { get; set; }
    public decimal Value { get; set; }
}
