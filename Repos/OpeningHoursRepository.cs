using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data;
using Reliable_Reservations.Models;
using Reliable_Reservations.Repositories.IRepos;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return await _context.OpeningHours
                .Include(o => o.SpecialOpeningHours)
                .Include(o => o.TimeSlots)
                .ToListAsync();
        }

        public async Task<OpeningHours?> GetByIdAsync(int id)
        {
            return await _context.OpeningHours
                .Include(o => o.SpecialOpeningHours)
                .Include(o => o.TimeSlots)
                .FirstOrDefaultAsync(o => o.OpeningHoursId == id);
        }

        public async Task AddAsync(OpeningHours openingHours)
        {
            _context.OpeningHours.Add(openingHours);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OpeningHours openingHours)
        {
            _context.OpeningHours.Update(openingHours);
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
        }
    }
}