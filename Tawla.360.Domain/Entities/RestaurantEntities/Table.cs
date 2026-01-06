using System;
using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Enums;

namespace Tawla._360.Domain.Entities.RestaurantEntities;

public class Table:BaseBranchEntity
{
    public string Name { get; set; }
    public TableStatus Status { get; set; }
}
