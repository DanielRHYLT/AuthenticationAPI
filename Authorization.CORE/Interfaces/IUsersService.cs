using Authorization.CORE.DTO_s;

namespace Authorization.CORE.Interfaces
{
    public interface IUsersService
    {
        Task<UserAuthenticationDTO> Login(UsersLoginDTO loginDTO);
        Task<bool> Register(UsersRegisterDTO registerDTO);
    }
}
