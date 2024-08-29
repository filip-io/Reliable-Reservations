﻿using Reliable_Reservations.Models;

namespace Reliable_Reservations.Repositories.IRepos
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetAllAsync();
        Task<Table?> GetByIdAsync(int id);
        Task<bool> TableNumberExistsAsync(int tableNumber);
        Task AddAsync(Table table);
        Task UpdateAsync(Table table);
        Task DeleteAsync(int id);
    }
}