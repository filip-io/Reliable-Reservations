﻿using Microsoft.AspNetCore.Mvc;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repos.IRepos;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {

        private readonly IMenuItemService _menuService;
        private readonly ILogger<MenuItemController> _logger;

        public MenuItemController(IMenuItemService menuService, ILogger<MenuItemController> logger)
        {
            _menuService = menuService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetAllMenuItemsAsync()
        {
            try
            {
                var menuItems = await _menuService.GetAllMenuItems();

                if (menuItems == null)
                {
                    return Ok("No menu items in database.");
                }
                else
                {
                    return Ok(menuItems);
                }
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDto>> GetMenuItemById(int id)
        {
            try
            {
                var menuItem = await _menuService.GetMenuItemById(id);

                if (menuItem == null)
                {
                    return ResponseHelper.HandleNotFound(_logger, id);
                }

                return Ok(menuItem);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<MenuItemDto>> CreateMenuItemAsync([FromBody] MenuItemCreateDto menuItemCreateDto)
        {
            try
            {
                var newMenuItem = await _menuService.CreateMenuItem(menuItemCreateDto);

                return CreatedAtAction(nameof(GetMenuItemById), new { id = newMenuItem.MenuItemId }, newMenuItem);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MenuItemDto>> UpdateMenuItemAsync(int id, MenuItemDto menuItemDto)
        {
            try
            {
                var updatedMenuItem = await _menuService.UpdateMenuItem(id, menuItemDto);
                return updatedMenuItem;
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuItemDto>> DeleteMenuItemAsync(int id)
        {
            try
            {
                await _menuService.DeleteMenuItem(id);
                return Ok($"Menu item with ID {id} was successfully deleted.");
            }
            catch (KeyNotFoundException)
            {
                return ResponseHelper.HandleNotFound(_logger, id);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }
    }
}