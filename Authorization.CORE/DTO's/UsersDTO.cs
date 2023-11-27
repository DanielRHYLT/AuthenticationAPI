using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.CORE.DTO_s
{
    public class UsersDTO
    {
        public int UserId { get; set; }

        public string? Username { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public string? Password { get; set; } = null!;

        public DateTime? RegistrationDate { get; set; }

        public int? RoleId { get; set; }
    }
    public class UsersLoginDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class UsersRegisterDTO
    {
        public string? Username { get; set; }
        public string? Email { get; set;}
        public string? Password { get; set; }
    }
    public class UserAuthenticationDTO
    {
        public int UserId { get; set; }

        public string? Username { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public string? Password { get; set; } = null!;

        public DateTime? RegistrationDate { get; set; }

        public int? RoleId { get; set; }

        public string? Token {  get; set; }
    }
   
}
