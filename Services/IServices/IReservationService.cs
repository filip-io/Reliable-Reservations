using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Models.ViewModels;

namespace Reliable_Reservations.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDetailsViewModel>> GetAllReservationsAsync();
        Task<ReservationDetailsViewModel?> GetReservationByIdAsync(int reservationId);
        Task<ReservationDetailsViewModel> CreateReservationAsync(ReservationCreateDto reservationCreateDto);
        Task<ReservationDetailsViewModel> UpdateReservationAsync(ReservationUpdateDto reservationUpdateDto);
        Task DeleteReservationAsync(int reservationId);
    }
}