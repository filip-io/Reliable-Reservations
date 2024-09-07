using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data.Repos.IRepos
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetAllAsync();
        Task<Table?> GetByIdAsync(int id);
        Task<bool> TableNumberExistsAsync(int tableNumber);
        Task<List<Table>> GetTablesByNumbersAsync(List<int> tableNumbers);
        Task<bool> TableHasTimeSlotAsync(List<Table> tables, int timeSlotId);
        Task AddAsync(Table table);
        Task UpdateAsync(Table table);
        Task DeleteAsync(Table table);
    }
}