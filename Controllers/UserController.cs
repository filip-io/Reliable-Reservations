using Microsoft.AspNetCore.Mvc;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Helpers;
using Reliable_Reservations.Models.DTOs.User;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    { 
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, ILogger<UserController> logger, IConfiguration configuration)
        {
            _userService = userService;
            _logger = logger;
            _configuration = configuration; 
        }

        [HttpPost("create")] // Add GetCustomerById controller and then CreatedAtAction to return the created user
        public async Task <ActionResult<UserDto>> Register(UserCreateDto userRegisterDto)
        {
            var newUser = await _userService.CreateUserAsync(userRegisterDto);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _userService.GetUserByEmailAsync(userLoginDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = JwtTokenGenerator.GenerateJwtToken(user, _configuration);

            return Ok(new { token });
        }
    }
}