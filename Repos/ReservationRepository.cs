using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data;
using Reliable_Reservations.Models;
using Reliable_Reservations.Repos.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reliable_Reservations.Repositories
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
                .Include(r => r.TimeSlot) // Eagerly load the TimeSlot associated with each Reservation
                .Where(r => r.Tables.Any(t => tables.Contains(t)) && // Check if any of the selected tables are in the reservation
                            r.TimeSlot.StartTime < endTime && // Ensure the TimeSlot overlaps with the specified time range
                            r.TimeSlot.EndTime > startTime)
                .ToListAsync(); // Execute the query and return the result as a list
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
                .Include(r => r.TimeSlot)
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