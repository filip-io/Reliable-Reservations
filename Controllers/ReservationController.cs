using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Services.IServices;
using Reliable_Reservations.Services;
using Reliable_Reservations.Models.ViewModels;

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

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ReservationDetailsViewModel>>> GetAllReservations()
        {
            try
            {
                var reservations = await _reservationService.GetAllReservationsAsync();

                if (reservations.IsNullOrEmpty())
                {
                    return Ok("No reservations in the database.");
                }

                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDetailsViewModel>> GetReservationById(int id)
        {
            try
            {
                var reservation = await _reservationService.GetReservationByIdAsync(id);

                if (reservation == null)
                {
                    return ResponseHelper.HandleNotFound(_logger, id);
                }
                return Ok(reservation);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<ReservationDetailsViewModel>> CreateReservation(ReservationCreateDto reservationCreateDto)
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
        public async Task<ActionResult<ReservationDetailsViewModel>> UpdateReservation(int id, ReservationUpdateDto reservationUpdateDto)
        {
            if (id != reservationUpdateDto.ReservationId)
            {
                return ResponseHelper.HandleBadRequest(_logger, "Reservation ID mismatch. Make sure ID matches in both URL and request body.");
            }
            try
            {
                var updatedReservation = await _reservationService.UpdateReservationAsync(reservationUpdateDto);
                return CreatedAtAction(nameof(GetReservationById), new { id = updatedReservation.ReservationId }, updatedReservation);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                await _reservationService.DeleteReservationAsync(id);
                return ResponseHelper.HandleSuccess(_logger, $"Reservation with ID {id} has been successfully deleted.");
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