using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data;
using Reliable_Reservations.Models;
using Reliable_Reservations.Repos.IRepos;

namespace Reliable_Reservations.Repos
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReliableReservationsDbContext _context;

        public ReservationRepository(ReliableReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.TimeSlot)
                .Include(r => r.Tables)
                .ToListAsync();
        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.TimeSlot)
                .Include(r => r.Tables)
                .FirstOrDefaultAsync(r => r.ReservationId == id);
        }

        public async Task AddAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}