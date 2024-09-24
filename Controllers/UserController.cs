using Microsoft.AspNetCore.Mvc;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models.DTOs.User;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Controllers
{
    public class UserController : ControllerBase
    { 
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("Register")]
        public async Task <ActionResult<UserDto>> Register(UserCreateDto userRegisterDto)
        {
            var newUser = await _userService.CreateUserAsync(userRegisterDto);

            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}