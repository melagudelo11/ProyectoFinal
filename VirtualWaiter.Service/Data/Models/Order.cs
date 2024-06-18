using System;
using System.Collections.Generic;

namespace VirtualWaiter.Service.Data.Models;

public partial class Order
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdEaterytable { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? Observation { get; set; }

    public float? Price { get; set; }

    public sbyte? Active { get; set; }

    public virtual ICollection<OrderDetail> OrderDetail { get; } = new List<OrderDetail>();
}
