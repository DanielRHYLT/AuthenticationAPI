using System;
using System.Collections.Generic;

namespace Authorization.CORE.Entities;

public partial class Roles
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; } = null!;

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
