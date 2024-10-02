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
                                 .Include(r => r.TimeSlots)
                                 .Include(r => r.Tables)
                                 .Include(r => r.Customer)
                                 .ToListAsync();
        }

        public async Task<Reservation?> GetReservationById(int reservationId)
        {
            return await _context.Reservations
                                 .Include(r => r.TimeSlots)
                                 .Include(r => r.Tables)
                                 .Include(r => r.Customer)
                                 .FirstOrDefaultAsync(r => r.ReservationId == reservationId);
        }


        public async Task<IEnumerable<Reservation>> GetReservationsByDate(DateTime date)
        {
            // Define the start and end of the day
            var startOfDay = date.Date; // This gives you the time at 00:00:00
            var endOfDay = date.Date.AddDays(1).AddTicks(-1); // This gives you 23:59:59.9999999

            return await _context.Reservations
                   .Include(r => r.Tables)
                   .Include(r => r.TimeSlots)
                   .Where(r => r.ReservationDate >= startOfDay && r.ReservationDate <= endOfDay)
                   .ToListAsync();
        }


        public async Task<IEnumerable<Reservation>> GetReservationsForTablesAsync(List<Table> tables, DateTime startTime, DateTime endTime)
        {
            return await _context.Reservations
                .Include(r => r.TimeSlots)
                .Where(r => r.Tables.Any(t => tables.Contains(t)) &&
                            (r.TimeSlots.Any(ts => ts.StartTime < endTime && ts.EndTime > startTime))) // Ensure overlapping time slots
                .ToListAsync();
        }



        public async Task<bool> AreTablesReservedAsync(List<int> tableIds, DateTime startTime, DateTime endTime)
        {
            return await _context.Reservations
                .Include(r => r.TimeSlots)
                .Where(r => r.TimeSlots.Any(ts => ts.StartTime < endTime && ts.EndTime > startTime) && // Check for overlapping time slots
                            r.Tables.Any(t => tableIds.Contains(t.TableId))) // Check if the tables are reserved
                .AnyAsync();
        }


        public async Task<Reservation> AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            var addedReservation = await _context.Reservations
                .Include(r => r.TimeSlots)
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