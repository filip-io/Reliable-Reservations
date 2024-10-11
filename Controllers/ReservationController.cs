using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models.DTOs.Reservation;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IReservationService reservationService, ILogger<ReservationController> logger)
        {
            _reservationService = reservationService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ReservationDetailsDto>>> GetAllReservations()
        {
            try
            {
                var reservations = await _reservationService.GetAllReservationsAsync();

                if (reservations.IsNullOrEmpty())
                {
                    return NotFound("No reservations in the database.");
                }

                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDetailsDto>> GetReservationById(int id)
        {
            try
            {
                var reservation = await _reservationService.GetReservationByIdAsync(id);
                return Ok(reservation);
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


        [HttpGet("date/{date}")]
        public async Task<ActionResult<ReservationDetailsDto>> GetReservationsByDate(DateTime date)
        {
            try
            {
                var reservations = await _reservationService.GetReservationsByDate(date);
                return Ok(reservations);
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


        [HttpGet("existing")]
        public async Task<ActionResult<IEnumerable<ReservationExistDto>>> GetExistingReservationsAsync(DateTime date)
        {
            try
            {
                var availability = await _reservationService.GetExistingReservationsAsync(date);
                return Ok(availability);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }


        [HttpPost("create")]
        public async Task<ActionResult<ReservationDetailsDto>> CreateReservation(ReservationCreateDto reservationCreateDto)
        {
            try
            {
                var reservation = await _reservationService.CreateReservationAsync(reservationCreateDto);
                return CreatedAtAction(nameof(GetReservationById), new { id = reservation.ReservationId }, reservation);
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
        public async Task<ActionResult<ReservationDetailsDto>> UpdateReservation(int id, ReservationUpdateDto reservationUpdateDto)
        {
            if (id != reservationUpdateDto.ReservationId)
            {
                return ResponseHelper.HandleBadRequest(_logger, "Reservation ID mismatch. Make sure ID matches in both URL and request body.");
            }
            try
            {
                var updatedReservation = await _reservationService.UpdateReservationAsync(reservationUpdateDto);
                return Ok(updatedReservation);
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                await _reservationService.DeleteReservationAsync(id);
                return ResponseHelper.HandleSuccess(_logger, $"Reservation with ID {id} has been successfully deleted.");
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