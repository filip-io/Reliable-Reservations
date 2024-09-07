using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data.Repos
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReliableReservationsDbContext _context;

        public ReservationRepository(ReliableReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _context.Reservations
                                 .Include(r => r.TimeSlot)
                                 .Include(r => r.Tables)
                                 .Include(r => r.Customer)
                                 .ToListAsync();
        }

        public async Task<Reservation?> GetReservationById(int reservationId)
        {
            return await _context.Reservations
                                 .Include(r => r.TimeSlot)
                                 .Include(r => r.Tables)
                                 .Include(r => r.Customer)
                                 .FirstOrDefaultAsync(r => r.ReservationId == reservationId);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsForTablesAsync(List<Table> tables, DateTime startTime, DateTime endTime)
        {
            return await _context.Reservations
                .Include(r => r.TimeSlot)
                .Where(r => r.Tables.Any(t => tables.Contains(t)) &&
                            r.TimeSlot.StartTime < endTime &&
                            r.TimeSlot.EndTime > startTime)
                .ToListAsync();
        }


        public async Task<bool> AreTablesReservedAsync(List<int> tableIds, int timeSlotId)
        {
            return await _context.Reservations
                .Where(r => r.TimeSlotId == timeSlotId)
                .AnyAsync(r => r.Tables.Any(t => tableIds.Contains(t.TableId)));
        }


        public async Task<Reservation> AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            var addedReservation = await _context.Reservations
                .Include(r => r.TimeSlot)
                .Include(r => r.Tables)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(r => r.ReservationId == reservation.ReservationId);

            return addedReservation;
        }

        public async Task<Reservation> UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();

            var updatedReservation = await _context.Reservations
                .Include(r => r.Tables)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(r => r.ReservationId == reservation.ReservationId);

            return updatedReservation;
        }

        public async Task DeleteReservation(Reservation reservationToDelete)
        {
            _context.Reservations.Remove(reservationToDelete);
            await _context.SaveChangesAsync();
        }
    }
}