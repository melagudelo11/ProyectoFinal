using System;
using System.Collections.Generic;

namespace VirtualWaiter.Service.Data.Models;

public partial class Eaterytable
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public int? Capacity { get; set; }

    public sbyte? Active { get; set; }

    public virtual ICollection<Order> Order { get; } = new List<Order>();
}
