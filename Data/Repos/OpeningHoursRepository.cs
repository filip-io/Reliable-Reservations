using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data.Repos
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
                .ToListAsync();
        }

        public async Task<OpeningHours?> GetOpeningHoursByDateAsync(DateTime date)
        {
            return await _context.OpeningHours
                                 .FirstOrDefaultAsync(oh => oh.DayOfWeek == date.DayOfWeek);
        }

        public async Task<OpeningHours?> GetByIdAsync(int id)
        {
            return await _context.OpeningHours
                .Include(o => o.SpecialOpeningHours)
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

        public async Task DeleteAsync(OpeningHours openingHoursToDelete)
        {
            _context.OpeningHours.Remove(openingHoursToDelete);
            await _context.SaveChangesAsync();
        }
    }
}