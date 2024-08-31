using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reliable_Reservations.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation?> GetReservationById(int reservationId);
        Task<IEnumerable<Reservation>> GetReservationsForTablesAsync(List<Table> tables, DateTime startTime, DateTime endTime);
        Task <Reservation> AddReservation(Reservation reservation);
        Task <Reservation> UpdateReservation(Reservation reservation);
        Task DeleteReservation(Reservation reservationToDelete);
    }
}
