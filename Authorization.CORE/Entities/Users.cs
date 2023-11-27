using System;
using System.Collections.Generic;

namespace Authorization.CORE.Entities;

public partial class Users
{
    public int UserId { get; set; }

    public string? Username { get; set; } = null!;

    public string? Email { get; set; } = null!;

    public string? Password { get; set; } = null!;

    public DateTime? RegistrationDate { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<PasswordResetTokens> PasswordResetTokens { get; set; } = new List<PasswordResetTokens>();

    public virtual Roles? Role { get; set; }
}
