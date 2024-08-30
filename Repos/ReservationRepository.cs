using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repos.IRepos;
using System.Collections.Generic;
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

        public async Task<Reservation> AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);

            await _context.SaveChangesAsync();

            var addedReservation = _context.Reservations
                .FirstOrDefault(r => r.ReservationId == reservation.ReservationId);

            return addedReservation;
        }

        public async Task<Reservation> UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);

            await _context.SaveChangesAsync();

            var updatedReservation = _context.Reservations
                .FirstOrDefault(r => r.ReservationId == reservation.ReservationId);

            return updatedReservation;
        }

        public async Task DeleteReservation(int reservationId)
        {
            var reservation = await GetReservationById(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}