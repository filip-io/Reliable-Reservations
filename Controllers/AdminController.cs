using Microsoft.AspNetCore.Mvc;
using Reliable_Reservations.Helpers;
using Reliable_Reservations.Models.DTOs.Admin;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    { 
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;
        private readonly IConfiguration _configuration;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger, IConfiguration configuration)
        {
            _adminService = adminService;
            _logger = logger;
            _configuration = configuration; 
        }

        [HttpPost("create")] // Add GetCustomerById controller and then CreatedAtAction to return the created user
        public async Task <IActionResult> Register(AdminCreateDto adminCreateDto)
        {
            var newAdmin = await _adminService.CreateAdminAsync(adminCreateDto);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(AdminLoginDto adminLoginDto)
        {
            var admin = await _adminService.GetAdminByEmailAsync(adminLoginDto.Email);

            if (admin == null || !BCrypt.Net.BCrypt.Verify(adminLoginDto.Password, admin.PasswordHash))
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = JwtTokenGenerator.GenerateJwtToken(admin, _configuration);

            return Ok(new { token });
        }
    }
}