using Reliable_Reservations.Models;

namespace Reliable_Reservations.Repositories.Interfaces
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetAllTablesAsync();
        Task<Table?> GetTableByIdAsync(int id);
        Task<bool> TableNumberExistsAsync(int tableNumber);
        Task AddTableAsync(Table table);
        Task UpdateTableAsync(Table table);
        Task DeleteTableAsync(int id);
    }
}