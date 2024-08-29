using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models.DTOs;
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

        // GET: api/OpeningHours/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<OpeningHoursDto>>> GetAllOpeningHours()
        {
            try
            {
                var openingHours = await _openingHoursService.GetAllOpeningHoursAsync();

                if (openingHours.IsNullOrEmpty())
                {
                    return Ok("No opening hours in database.");
                }
                else
                {
                    return Ok(openingHours);
                }
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        // GET: api/OpeningHours/get/{id}
        [HttpGet("get/{id}")]
        public async Task<ActionResult<OpeningHoursDto>> GetOpeningHoursById(int id)
        {
            try
            {
                var openingHours = await _openingHoursService.GetOpeningHoursByIdAsync(id);

                if (openingHours == null)
                {
                    return ResponseHelper.HandleNotFound(_logger, id);
                }
                return Ok(openingHours);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        // POST: api/OpeningHours/create
        [HttpPost("create")]
        public async Task<ActionResult<OpeningHoursDto>> CreateOpeningHours(OpeningHoursCreateDto openingHoursCreateDto)
        {
            try
            {
                var createdOpeningHours = await _openingHoursService.CreateOpeningHoursAsync(openingHoursCreateDto);

                var locationUrl = Url.Action(nameof(GetOpeningHoursById), new { id = createdOpeningHours.OpeningHoursId });

                // Log the URL for debugging purposes
                _logger.LogInformation("Redirecting to: {LocationUrl}", locationUrl);

                return CreatedAtAction(nameof(GetOpeningHoursById), new { id = createdOpeningHours.OpeningHoursId }, createdOpeningHours);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        // PUT: api/OpeningHours/update/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult<OpeningHoursDto>> UpdateOpeningHours(int id, OpeningHoursDto openingHoursDto)
        {
            if (id != openingHoursDto.OpeningHoursId)
            {
                return ResponseHelper.HandleBadRequest(_logger, "Opening Hours ID mismatch. Make sure ID matches in both URL and request body.");
            }
            try
            {
                var updatedOpeningHours = await _openingHoursService.UpdateOpeningHoursAsync(openingHoursDto);
                return CreatedAtAction(nameof(GetOpeningHoursById), new { id = updatedOpeningHours.OpeningHoursId }, updatedOpeningHours);
            }
            catch (KeyNotFoundException)
            {
                return ResponseHelper.HandleNotFound(_logger, id);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        // DELETE: api/OpeningHours/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteOpeningHours(int id)
        {
            try
            {
                await _openingHoursService.DeleteOpeningHoursAsync(id);
                return ResponseHelper.HandleSuccess(_logger, $"Opening Hours with ID {id} has been successfully deleted.");
            }
            catch (KeyNotFoundException)
            {
                return ResponseHelper.HandleNotFound(_logger, id);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }
    }
}