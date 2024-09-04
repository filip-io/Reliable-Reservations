using Reliable_Reservations.Models.DTOs;

namespace Reliable_Reservations.Services.IServices
{
    public interface ITimeSlotService
    {
        Task<TimeSlotDto> GetTimeSlotByIdAsync(int id);
        Task<IEnumerable<TimeSlotDto>> GetAllTimeSlotsAsync();
        Task<TimeSlotDto> CreateTimeSlotAsync(TimeSlotCreateDto timeSlotCreateDto);
        Task UpdateTimeSlotAsync(int id, TimeSlotUpdateDto timeSlotCreateDto);
        Task DeleteTimeSlotAsync(int id);
    }
}
