﻿using Reliable_Reservations.Models.DTOs.TimeSlot;

namespace Reliable_Reservations.Services.IServices
{
    public interface ITimeSlotService
    {
        Task<TimeSlotDto> GetTimeSlotByIdAsync(int id);
        Task<IEnumerable<TimeSlotDto>> GetTimeSlotsByIds(List<int> ids);
        Task<IEnumerable<TimeSlotDto>> GetAllTimeSlotsAsync();
        Task<IEnumerable<TimeSlotDto>> GetTimeSlotsByDateAsync(DateTime date);
        Task<IEnumerable<TimeSlotDto>> GetTimeSlotsForWeekAsync(DateTime chosenDate);
        Task<IEnumerable<TimeSlotDto>> GetTimeSlotsByTablesAsync(IEnumerable<int> tableIds);
        Task<TimeSlotDto> CreateTimeSlotAsync(TimeSlotCreateDto timeSlotCreateDto);
        Task<IEnumerable<TimeSlotDto>> AutoGenerateTimeSlots(TimeSlotAutoGenerateDto timeSlotAutoGenerateDto);
        Task UpdateTimeSlotAsync(int id, TimeSlotUpdateDto timeSlotCreateDto);
        Task DeleteTimeSlotAsync(int id);
    }
}
