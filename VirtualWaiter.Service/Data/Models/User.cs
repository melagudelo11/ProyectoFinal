using System;
using System.Collections.Generic;

namespace VirtualWaiter.Service.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string? RoleCode { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Identification { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public sbyte? Active { get; set; }

    public virtual ICollection<Order> Order { get; } = new List<Order>();
}
