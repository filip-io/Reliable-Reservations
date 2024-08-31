using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;

namespace Reliable_Reservations.Repos.IRepos
{
    public interface IMenuItemRepository
    {
        Task<IEnumerable<MenuItem>> GetAllMenuItems();
        Task<MenuItem?> GetMenuItemById(int id);
        Task AddMenuItem(MenuItem menuItem);
        Task UpdateMenuItem(MenuItem menuItem);
        Task DeleteMenuItem(int id);
    }
}
