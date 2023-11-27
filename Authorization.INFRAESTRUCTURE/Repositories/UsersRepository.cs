using Microsoft.EntityFrameworkCore;
using Authorization.CORE.DTO_s;
using Authorization.CORE.Entities;
using Authorization.INFRAESTRUCTURE.Data;
using Authorization.CORE.Interfaces;

namespace Authorization.INFRAESTRUCTURE.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DbauthContext _dbContext;

        public UsersRepository(DbauthContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Users> Login(UsersLoginDTO usersLoginDTO)
        {
            var result = await _dbContext
                .Users
                .Where(z => z.Email == usersLoginDTO.Email
                        && z.Password == usersLoginDTO.Password)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Register(Users users)
        {
            await _dbContext.Users.AddAsync(users);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<Users> GetById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<bool> ExistsEmail(string email)
        {
            return await _dbContext.Users.Where(x => x.Email == email).AnyAsync();
        }
    }
}
