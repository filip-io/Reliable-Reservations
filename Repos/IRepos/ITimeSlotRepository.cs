﻿using Reliable_Reservations.Models;

namespace Reliable_Reservations.Repos.IRepos
{
    public interface ITimeSlotRepository
    {
        Task<IEnumerable<TimeSlot>> GetAllTimeSlots();
        Task<TimeSlot?> GetTimeSlotById(int id);
        Task AddTimeSlot(TimeSlot timeSlot);
        Task UpdateTimeSlot(TimeSlot timeSlot);
        Task DeleteTimeSlot(int id);
        Task<bool> TimeSlotExists(int id);
    }
}