﻿using Reliable_Reservations.Models;

namespace Reliable_Reservations.Repositories.IRepos
{
    public interface IOpeningHoursRepository
    {
        Task<IEnumerable<OpeningHours>> GetAllAsync();
        Task<OpeningHours?> GetByIdAsync(int id);
        Task AddAsync(OpeningHours openingHours);
        Task UpdateAsync(OpeningHours openingHours);
        Task DeleteAsync(int id);
    }
}