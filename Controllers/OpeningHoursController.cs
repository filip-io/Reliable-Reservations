using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reliable_Reservations.Models.DTOs.OpeningHours;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpeningHoursController : ControllerBase
    {
        private readonly IOpeningHoursService _openingHoursService;
        private readonly ILogger<OpeningHoursController> _logger;

        public OpeningHoursController(IOpeningHoursService openingHoursService, ILogger<OpeningHoursController> logger)
        {
            _openingHoursService = openingHoursService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<OpeningHoursDto>>> GetAllOpeningHours()
        {
            try
            {
                var openingHours = await _openingHoursService.GetAllOpeningHoursAsync();
                if (openingHours == null || !openingHours.Any())
                {
                    return NotFound("No opening hours found.");
                }
                return Ok(openingHours);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all opening hours.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OpeningHoursDto>> GetOpeningHoursById(int id)
        {
            try
            {
                var openingHours = await _openingHoursService.GetOpeningHoursByIdAsync(id);
                return Ok(openingHours);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult<OpeningHoursDto>> CreateOpeningHours([FromBody] OpeningHoursCreateDto openingHoursCreateDto)
        {
            try
            {
                var createdOpeningHours = await _openingHoursService.CreateOpeningHoursAsync(openingHoursCreateDto);
                return CreatedAtAction(nameof(GetOpeningHoursById), new { id = createdOpeningHours.OpeningHoursId }, createdOpeningHours);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating opening hours.");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<OpeningHoursDto>> UpdateOpeningHours(int id, [FromBody] OpeningHoursDto openingHoursDto)
        {
            if (id != openingHoursDto.OpeningHoursId)
            {
                return BadRequest("ID mismatch.");
            }
            try
            {
                var updatedOpeningHours = await _openingHoursService.UpdateOpeningHoursAsync(openingHoursDto);
                return Ok(updatedOpeningHours);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Opening hours with ID {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating opening hours with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOpeningHours(int id)
        {
            try
            {
                await _openingHoursService.DeleteOpeningHoursAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Opening hours with ID {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting opening hours with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}