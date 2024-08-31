using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Services;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private readonly ITimeSlotService _timeSlotService;
        private readonly ILogger<TimeSlotController> _logger;

        public TimeSlotController(ITimeSlotService timeSlotService, ILogger<TimeSlotController> logger)
        {
            _timeSlotService = timeSlotService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<TimeSlotDto>>> GetAllTimeSlots()
        {
            try
            {
                var timeSlots = await _timeSlotService.GetAllTimeSlotsAsync();
                
                if (timeSlots.IsNullOrEmpty())
                {
                    return Ok("No timeslots in database.");
                }
                else
                {
                    return Ok(timeSlots);
                }
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSlotDto>> GetTimeSlotById(int id)
        {
            try
            {
                var timeSlot = await _timeSlotService.GetTimeSlotByIdAsync(id);
                
                if (timeSlot == null)
                {
                    return ResponseHelper.HandleNotFound(_logger, id);
                }
                return Ok(timeSlot);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<TimeSlotDto>> CreateTimeSlot(TimeSlotCreateDto timeSlotCreateDto)
        {
            try
            {
                var createdTimeSlot = await _timeSlotService.CreateTimeSlotAsync(timeSlotCreateDto);
                return CreatedAtAction(nameof(GetTimeSlotById), new { id = createdTimeSlot.TimeSlotId }, createdTimeSlot);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeSlot(int id, TimeSlotCreateDto timeSlotCreateDto)
        {
            try
            {
                await _timeSlotService.UpdateTimeSlotAsync(id, timeSlotCreateDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeSlot(int id)
        {
            try
            {
                await _timeSlotService.DeleteTimeSlotAsync(id);
                return ResponseHelper.HandleSuccess(_logger, $"Timeslot with ID {id} has been successfully deleted.");
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
