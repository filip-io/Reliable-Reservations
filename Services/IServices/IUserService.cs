using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs.User;

namespace Reliable_Reservations.Services.IServices
{
    public interface IUserService
    {
        Task<UserDto?> GetUserByIdAsync(int id); 
        Task<UserDto?> GetUserByEmailAsync(string email);
        Task<UserDto?> CreateUserAsync(UserCreateDto user);
    }
}
