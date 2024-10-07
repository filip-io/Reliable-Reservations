using Microsoft.AspNetCore.Mvc;

namespace Reliable_Reservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Status = "Online" });
        }
    }
}