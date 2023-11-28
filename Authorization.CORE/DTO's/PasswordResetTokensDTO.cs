using Authorization.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.CORE.DTO_s
{
    public class PasswordResetTokensDTO
    {
        public int TokenId { get; set; }
        public int? UserId { get; set; }
        public string? Token { get; set; } = null!;
        public DateTime? ExpiryDate { get; set; }
        public virtual Users? User { get; set; }
    }
}

