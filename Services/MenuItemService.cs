using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repos.IRepos;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuItemService> _logger;

        public MenuItemService(IMenuItemRepository menuRepository, IMapper mapper, ILogger<MenuItemService> logger)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<MenuItemDto>> GetAllMenuItems()
        {
            var menuItems = await _menuRepository.GetAllMenuItems();
            var menuItemsList = _mapper.Map<IEnumerable<MenuItemDto>>(menuItems);
            return menuItemsList;
        }

        public async Task<MenuItemDto?> GetMenuItemById(int id)
        {
            try
            {
                var menuItem = await _menuRepository.GetMenuItemById(id);

                var menuItemDto = _mapper.Map<MenuItemDto>(menuItem);

                return menuItemDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while retrieving the menu item.");
                throw new ApplicationException("An unexpected error occurred while retrieving the menu item.", ex);
            }
        }

        public async Task<MenuItemDto> CreateMenuItem(MenuItemCreateDto menuItemDto)
        {
            var newMenuItem = _mapper.Map<MenuItem>(menuItemDto);

            await _menuRepository.AddMenuItem(newMenuItem);

            return _mapper.Map<MenuItemDto>(newMenuItem);
        }

        public async Task<MenuItemDto> UpdateMenuItem(int id, MenuItemDto menuItemDto)
        {
            var menuItemToUpdate = await _menuRepository.GetMenuItemById(id);

            if (menuItemToUpdate == null)
            {
                throw new KeyNotFoundException($"No menu item with ID {id} found.");
            }

            _mapper.Map(menuItemDto, menuItemToUpdate);
            await _menuRepository.UpdateMenuItem(menuItemToUpdate);
            return _mapper.Map<MenuItemDto>(menuItemToUpdate);
        }

        public async Task DeleteMenuItem(int id)
        {
            await _menuRepository.DeleteMenuItem(id);
        }
    }
}