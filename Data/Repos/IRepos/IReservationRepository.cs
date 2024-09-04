using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data.Repos.IRepos
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation?> GetReservationById(int reservationId);
        Task<IEnumerable<Reservation>> GetReservationsForTablesAsync(List<Table> tables, DateTime startTime, DateTime endTime);
        Task<Reservation> AddReservation(Reservation reservation);
        Task<Reservation> UpdateReservation(Reservation reservation);
        Task DeleteReservation(Reservation reservationToDelete);
    }
}
