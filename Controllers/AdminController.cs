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

        [HttpPost("create")]
        public async Task<IActionResult> CreateAdminAsync(AdminCreateDto adminCreateDto)
        {
            await _adminService.CreateAdminAsync(adminCreateDto);

            string message = $"New admin with name {adminCreateDto.FirstName} {adminCreateDto.LastName} has been successfully created.";

            return StatusCode(201, new { message });
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAdminAsync(AdminLoginDto adminLoginDto)
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