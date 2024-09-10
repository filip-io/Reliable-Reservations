using Reliable_Reservations.Models.DTOs.OpeningHours;

namespace Reliable_Reservations.Services.IServices
{
    public interface IOpeningHoursService
    {
        Task<IEnumerable<OpeningHoursDto>> GetAllOpeningHoursAsync();
        Task<OpeningHoursDto?> GetOpeningHoursByIdAsync(int id);
        Task<OpeningHoursDto> CreateOpeningHoursAsync(OpeningHoursCreateDto openingHoursCreateDto);
        Task<OpeningHoursDto> UpdateOpeningHoursAsync(OpeningHoursDto openingHoursDto);
        Task DeleteOpeningHoursAsync(int id);
    }
}