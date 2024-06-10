using System;
using System.Collections.Generic;

namespace VirtualWaiter.Service.Data.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public float? Price { get; set; }

    public sbyte? Active { get; set; }

    public virtual ICollection<OrderDetail> OrderDetail { get; } = new List<OrderDetail>();
}
