using Microsoft.Extensions.Options;
using Authorization.CORE.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authorization.CORE.Entities;
using Authorization.CORE.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Authorization.INFRAESTRUCTURE.Shared
{
    public class JWTServices : IJWTService
    {
        public JWTSettings _settings {  get; }
        public JWTServices(IOptions<JWTSettings>settings)
        {
            _settings = settings.Value;
        }

        public string GenerateJWToken(Users users)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sc);

            var claims = new[]{
                    new Claim(ClaimTypes.Name, (users.Username + "")),
                    new Claim(ClaimTypes.GivenName, users.Username),
                    new Claim(ClaimTypes.Email, users.Email),
                    new Claim(ClaimTypes.Role, users.RoleId.ToString() == "1"? "Admin": "User"),
                    new Claim("UserId", users.UserId.ToString()),
                };
            var payload = new JwtPayload(
                _settings.Issuer
                , _settings.Audience
                , claims
                , DateTime.UtcNow
                , DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes));
            var Token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(Token); 
        }
    }
}
