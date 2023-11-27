using Authorization.CORE.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Authorization.CORE.DTO_s;

namespace Authorization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UsersLoginDTO usersLoginDTO)
        {
            var result = await _usersService.Login(usersLoginDTO);
            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UsersRegisterDTO usersRegisterDTO)
        {
            var result = await _usersService.Register(usersRegisterDTO);
            if(!result)
                return NotFound();
            return Ok(result);
        }
    }
}
