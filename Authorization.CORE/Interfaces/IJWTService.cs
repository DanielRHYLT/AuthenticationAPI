using Authorization.CORE.Entities;
using Authorization.CORE.Settings;

namespace Authorization.CORE.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(Users users);
    }
}
