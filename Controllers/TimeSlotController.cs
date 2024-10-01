﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models.DTOs.TimeSlot;
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

        //[HttpGet("all")]
        //public async Task<ActionResult<IEnumerable<TimeSlotDto>>> GetAllTimeSlots()
        //{
        //    try
        //    {
        //        var timeSlots = await _timeSlotService.GetAllTimeSlotsAsync();

        //        if (timeSlots.IsNullOrEmpty())
        //        {
        //            return Ok("No timeslots in database.");
        //        }
        //        else
        //        {
        //            return Ok(timeSlots);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ResponseHelper.HandleException(_logger, ex);
        //    }
        //}


        [HttpGet("daily/{date}")]
        public async Task<ActionResult<IEnumerable<TimeSlotDto>>> GetTimeSlotByDateAsync(DateTime date)
        {
            try
            {
                var timeSlots = await _timeSlotService.GetTimeSlotsByDateAsync(date);

                if (timeSlots.IsNullOrEmpty())
                {
                    return NotFound("No timeslots for the chosen date in database.");
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





        [HttpGet("weekly/{date}")]
        public async Task<ActionResult<IEnumerable<TimeSlotDto>>> GetWeeklyTimeSlots(DateTime date)
        {
            try
            {
                var timeSlots = await _timeSlotService.GetTimeSlotsForWeekAsync(date);

                if (timeSlots.IsNullOrEmpty())
                {
                    return NotFound("No timeslots for the chosen date in database.");
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
                return Ok(timeSlot);
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


        [HttpPost("createMultiple")]
        public async Task<ActionResult<TimeSlotDto>> CreateTimeSlotsByDateRange(TimeSlotAutoGenerateDto timeSlotAutoCreateDto)
        {
            try
            {
                var createdTimeSlot = await _timeSlotService.AutoGenerateTimeSlots(timeSlotAutoCreateDto);
                return ResponseHelper.HandleSuccess(_logger, "Successfully created new TimeSlots.");
            }
            catch (InvalidOperationException ex)
            {
                return ResponseHelper.HandleBadRequest(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeSlot(int id, TimeSlotUpdateDto timeSlotUpdateDto)
        {
            try
            {
                await _timeSlotService.UpdateTimeSlotAsync(id, timeSlotUpdateDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeSlotDto>> DeleteTimeSlot(int id)
        {
            try
            {
                await _timeSlotService.DeleteTimeSlotAsync(id);
                return ResponseHelper.HandleSuccess(_logger, $"Timeslot with ID {id} has been successfully deleted.");
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
    }
}
