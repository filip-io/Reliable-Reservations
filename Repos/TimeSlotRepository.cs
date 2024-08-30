using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data;
using Reliable_Reservations.Models;
using Reliable_Reservations.Repos.IRepos;

namespace Reliable_Reservations.Repos
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly ReliableReservationsDbContext _context;

        public TimeSlotRepository(ReliableReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TimeSlot>> GetAllTimeSlots()
        {
            return await _context.TimeSlots.ToListAsync();
        }

        public async Task<TimeSlot?> GetTimeSlotById(int id)
        {
            return await _context.TimeSlots.FindAsync(id);
        }

        public async Task<TimeSlot?> GetTimeSlotByDate(DateTime reservationDate)
        {
            // Extract time only from reservationDate if needed, adjust query as appropriate
            var dateOnly = reservationDate.Date;
            var timeOnly = reservationDate.TimeOfDay;

            return await _context.TimeSlots
                .Where(ts => 
                ts.StartTime.Date == dateOnly && 
                ts.StartTime.TimeOfDay <= timeOnly && 
                ts.EndTime.TimeOfDay >= timeOnly)
                .FirstOrDefaultAsync();
        }

        public async Task AddTimeSlot(TimeSlot timeSlot)
        {
            _context.TimeSlots.Add(timeSlot);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTimeSlot(TimeSlot timeSlot)
        {
            _context.Entry(timeSlot).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTimeSlot(int id)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(id);
            if (timeSlot != null)
            {
                _context.TimeSlots.Remove(timeSlot);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> TimeSlotExists(int id)
        {
            return await _context.TimeSlots.AnyAsync(ts => ts.TimeSlotId == id);
        }
    }
}
