using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repos.IRepos;

namespace Reliable_Reservations.Repos
{
    public class MenuItemRepository : IMenuItemRepository
    {

        private readonly ReliableReservationsDbContext _context;

        public MenuItemRepository(ReliableReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem?> GetMenuItemById(int id)
        {
            MenuItem? menuItem = await _context.MenuItems.FirstOrDefaultAsync(i => i.MenuItemId == id);
            return menuItem;
        }

        public async Task AddMenuItem(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem); // await with async method?
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}