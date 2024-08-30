using Reliable_Reservations.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reliable_Reservations.Services.IServices
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDto>> GetAllReservationsAsync();
        Task<ReservationDto?> GetReservationByIdAsync(int id);
        Task<ReservationDto> CreateReservationAsync(ReservationCreateDto reservationCreateDto);
        Task<ReservationDto> UpdateReservationAsync(ReservationDto reservationDto);
        Task DeleteReservationAsync(int id);
    }
}