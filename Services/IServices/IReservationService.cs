using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Reliable_Reservations.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDto>> GetAllReservationsAsync();
        Task<ReservationDto?> GetReservationByIdAsync(int reservationId);
        Task<ReservationDto> CreateReservationAsync(ReservationCreateDto reservationCreateDto);
        Task<ReservationDto> UpdateReservationAsync(ReservationDto reservationUpdateDto);
        Task DeleteReservationAsync(int reservationId);
    }
}