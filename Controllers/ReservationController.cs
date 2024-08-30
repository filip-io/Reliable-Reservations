﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models.DTOs;
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

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetAllReservations()
        {
            try
            {
                var reservations = await _reservationService.GetAllReservationsAsync();

                if (reservations.IsNullOrEmpty())
                {
                    return Ok("No reservations in database.");
                }

                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetReservationById(int id)
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
        public async Task<ActionResult<ReservationDto>> CreateReservation(ReservationCreateDto reservationCreateDto)
        {
            try
            {
                var reservation = await _reservationService.CreateReservationAsync(reservationCreateDto);
                return CreatedAtAction(nameof(GetReservationById), new { id = reservation.ReservationId }, reservation);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, ReservationDto reservationDto)
        {
            if (id != reservationDto.ReservationId)
            {
                return ResponseHelper.HandleBadRequest(_logger, "Reservation ID mismatch. Make sure ID matches in both URL and request body.");
            }
            try
            {
                var updatedReservation = await _reservationService.UpdateReservationAsync(reservationDto);
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