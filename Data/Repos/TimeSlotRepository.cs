﻿using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data.Repos
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



        public async Task<IEnumerable<TimeSlot>> GetTimeSlotsByDateAsync(DateTime date)
        {
            // Start of the day for the provided date
            var startOfDay = date.Date;

            // End of the day for the provided date
            var endOfDay = startOfDay.AddDays(1).AddTicks(-1);

            // Fetch time slots where the StartTime is before the end of the day and EndTime is after the start of the day
            return await _context.TimeSlots
                .AsNoTracking()
                .Where(ts => ts.StartTime <= endOfDay && ts.EndTime >= startOfDay)
                .ToListAsync();
        }



        public async Task<IEnumerable<TimeSlot>> GetTimeSlotsForDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.TimeSlots
                .AsNoTracking()
                .Where(ts => ts.StartTime >= startDate && ts.StartTime <= endDate)
                .OrderBy(ts => ts.StartTime)
                .ToListAsync();
        }

        public async Task<TimeSlot?> GetTimeSlotByDate(DateTime reservationDate)
        {

            var dateOnly = reservationDate.Date;
            var timeOnly = reservationDate.TimeOfDay;

            return await _context.TimeSlots
                .Where(ts =>
                ts.StartTime.Date == dateOnly &&
                ts.StartTime.TimeOfDay <= timeOnly &&
                ts.EndTime.TimeOfDay >= timeOnly)
                .FirstOrDefaultAsync();
        }


        public async Task<TimeSlot?> GetTimeSlotById(int id)
        {
            return await _context.TimeSlots.FindAsync(id);
        }


        public async Task<IEnumerable<TimeSlot>> GetTimeSlotsByIds(List<int> timeSlotIds)
        {
            return await _context.TimeSlots
                .Where(ts => timeSlotIds.Contains(ts.TimeSlotId))
                .ToListAsync();
        }


        public async Task<bool> TimeSlotExists(int id)
        {
            return await _context.TimeSlots.AnyAsync(ts => ts.TimeSlotId == id);
        }


        public async Task<IEnumerable<TimeSlot>> GetTimeSlotsByTableIdsAsync(IEnumerable<int> tableIds)
        {
            return await _context.TimeSlots
                .Where(ts => tableIds.Contains(ts.TableId))
                .ToListAsync();
        }


        public async Task AddTimeSlot(TimeSlot timeSlot)
        {
            _context.TimeSlots.Add(timeSlot);
            await _context.SaveChangesAsync();
        }

        public async Task AddMultipleTimeSlots(IEnumerable<TimeSlot> timeSlots)
        {
            await _context.TimeSlots.AddRangeAsync(timeSlots);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTimeSlot(TimeSlot timeSlot)
        {
            _context.Entry(timeSlot).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTimeSlot(TimeSlot timeSlot)
        {
            _context.TimeSlots.Remove(timeSlot);
            await _context.SaveChangesAsync();
        }
    }
}
