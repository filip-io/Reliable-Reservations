using Reliable_Reservations.Models.DTOs.Reservation;

namespace Reliable_Reservations.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDetailsDto>> GetAllReservationsAsync();
        Task<ReservationDetailsDto?> GetReservationByIdAsync(int reservationId);
        Task<ReservationDetailsDto> CreateReservationAsync(ReservationCreateDto reservationCreateDto);
        Task<ReservationDetailsDto> UpdateReservationAsync(ReservationUpdateDto reservationUpdateDto);
        Task DeleteReservationAsync(int reservationId);
    }
}