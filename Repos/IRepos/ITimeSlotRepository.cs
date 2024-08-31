using Reliable_Reservations.Models;

namespace Reliable_Reservations.Repos.IRepos
{
    public interface ITimeSlotRepository
    {
        Task<IEnumerable<TimeSlot>> GetAllTimeSlots();
        Task<TimeSlot?> GetTimeSlotById(int id);
        Task<bool> TimeSlotExists(int id);
        Task<TimeSlot> GetTimeSlotByDate(DateTime reservationDate);
        Task AddTimeSlot(TimeSlot timeSlot);
        Task UpdateTimeSlot(TimeSlot timeSlot);
        Task DeleteTimeSlot(TimeSlot timeslot);
    }
}
