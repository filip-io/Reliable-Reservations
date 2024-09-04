using Reliable_Reservations.Models.DTOs;

namespace Reliable_Reservations.Services.IServices
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemDto>> GetAllMenuItems();
        Task<MenuItemDto> GetMenuItemById(int id);
        Task<MenuItemDto> CreateMenuItem(MenuItemCreateDto menuItemDto);
        Task<MenuItemDto> UpdateMenuItem(int id, MenuItemDto menuItemDto);
        Task DeleteMenuItem(int id);
    }
}
