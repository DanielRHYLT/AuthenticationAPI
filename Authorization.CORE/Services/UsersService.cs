using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authorization.CORE.DTO_s;
using Authorization.CORE.Entities;
using Authorization.CORE.Interfaces;

namespace Authorization.CORE.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJWTService _jwtService;

        public UsersService(IUsersRepository usersRepository, IJWTService jwtService)
        {
            _usersRepository = usersRepository;
            _jwtService = jwtService;
        }
        public async Task<UserAuthenticationDTO> Login(UsersLoginDTO usersLoginDTO)
        {
            var users = await _usersRepository.Login(usersLoginDTO);

            if(users == null)
            {
                return null;
            }

            var token = _jwtService.GenerateJWToken(users);

            var usersDTO = new UserAuthenticationDTO();
            usersDTO.UserId = users.UserId;
            usersDTO.Username = users.Username; 
            usersDTO.Email = users.Email;
            usersDTO.Password = users.Password;
            usersDTO.RoleId = users.RoleId;
            usersDTO.Token = token;

            return usersDTO;
        }
        public async Task<bool> Register(UsersRegisterDTO usersRegisterDTO)
        {
            var exists = await _usersRepository.ExistsEmail(usersRegisterDTO.Email);
            if (exists) return false;

            var users = new Users()
            {
                Username = usersRegisterDTO.Username,
                Email = usersRegisterDTO.Email,
                Password = usersRegisterDTO.Password,
                RoleId = 2
            };

            var result = await _usersRepository.Register(users);
            return result;
        }
    }
}
