using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data.Repos.IRepos
{
    public interface IAdminRepository
    {
        Task<Admin?> GetAdminByIdAsync(int id);
        Task<Admin?> GetAdminByEmailAsync(string email);
        Task<bool> AdminExistsAsync(string email);
        Task AddAdminAsync(Admin admin);
    }
}
