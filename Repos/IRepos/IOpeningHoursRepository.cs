using Reliable_Reservations.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reliable_Reservations.Repositories.IRepos
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