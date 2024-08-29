using Reliable_Reservations.Models.DTOs;

namespace Reliable_Reservations.Services.IServices
{
    public interface ITableService
    {
        Task<IEnumerable<TableDto>> GetAllTablesAsync();
        Task<TableDto?> GetTableByIdAsync(int id);
        Task<TableDto> CreateTableAsync(TableCreateDto tableCreateDto);
        Task<TableDto> UpdateTableAsync(int id, TableCreateDto tableCreateDto);
        Task DeleteTableAsync(int id);
    }
}