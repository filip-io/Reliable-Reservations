using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data.Repos.IRepos
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
