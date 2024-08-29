using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data;
using Reliable_Reservations.Models;
using Reliable_Reservations.Repositories.IRepos;

namespace Reliable_Reservations.Repositories
{
    public class OpeningHoursRepository : IOpeningHoursRepository
    {
        private readonly ReliableReservationsDbContext _context;

        public OpeningHoursRepository(ReliableReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OpeningHours>> GetAllAsync()
        {
            return await _context.OpeningHours.ToListAsync();
        }

        public async Task<OpeningHours?> GetByIdAsync(int id)
        {
            return await _context.OpeningHours.FindAsync(id);
        }

        public async Task AddAsync(OpeningHours openingHours)
        {
            _context.OpeningHours.Add(openingHours);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OpeningHours openingHours)
        {
            var existingOpeningHours = await _context.OpeningHours.FindAsync(openingHours.OpeningHoursId);
            if (existingOpeningHours == null)
            {
                throw new KeyNotFoundException($"Opening hours with ID {openingHours.OpeningHoursId} not found.");
            }

            // Only update changed values for efficiency and optimization
            _context.Entry(existingOpeningHours).CurrentValues.SetValues(openingHours);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var openingHours = await _context.OpeningHours.FindAsync(id);
            if (openingHours != null)
            {
                _context.OpeningHours.Remove(openingHours);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Opening hours with ID {id} not found.");
            }
        }
    }
}