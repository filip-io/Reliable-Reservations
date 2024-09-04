using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data.Repos.IRepos
{
    public interface IOpeningHoursRepository
    {
        Task<IEnumerable<OpeningHours>> GetAllAsync();
        Task<OpeningHours?> GetByIdAsync(int id);
        Task<OpeningHours?> GetOpeningHoursByDateAsync(DateTime date);
        Task AddAsync(OpeningHours openingHours);
        Task UpdateAsync(OpeningHours openingHours);
        Task DeleteAsync(OpeningHours openingHours);
    }
}