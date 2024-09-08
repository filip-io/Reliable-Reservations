using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data.Repos.IRepos
{
    public interface ITimeSlotRepository
    {
        Task<IEnumerable<TimeSlot>> GetAllTimeSlots();
        Task<IEnumerable<TimeSlot>> GetTimeSlotsForDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<TimeSlot?> GetTimeSlotById(int id);
        Task<bool> TimeSlotExists(int id);
        Task<TimeSlot> GetTimeSlotByDate(DateTime reservationDate);
        Task<IEnumerable<TimeSlot>> GetTimeSlotsByTableIdsAsync(IEnumerable<int> tableIds);
        Task AddTimeSlot(TimeSlot timeSlot);
        Task AddMultipleTimeSlots(IEnumerable<TimeSlot> timeSlots);
        Task UpdateTimeSlot(TimeSlot timeSlot);
        Task DeleteTimeSlot(TimeSlot timeslot);
    }
}
