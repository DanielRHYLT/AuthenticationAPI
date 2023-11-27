using Authorization.CORE.DTO_s;
using Authorization.CORE.Entities;

namespace Authorization.CORE.Interfaces
{
    public interface IUsersRepository
    {
        Task<Users> Login(UsersLoginDTO loginDTO);
        Task<bool> Register(Users users);
        Task<Users> GetById(int id);
        Task<bool> ExistsEmail(string email);
    }
}
