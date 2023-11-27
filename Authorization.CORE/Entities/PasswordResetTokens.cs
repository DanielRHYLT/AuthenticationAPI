using System;
using System.Collections.Generic;

namespace Authorization.CORE.Entities;

public partial class PasswordResetTokens
{
    public int TokenId { get; set; }

    public int? UserId { get; set; }

    public string? Token { get; set; } = null!;

    public DateTime? ExpiryDate { get; set; }

    public virtual Users? User { get; set; }
}
