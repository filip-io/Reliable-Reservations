using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs.Admin;

namespace Reliable_Reservations.Services.IServices
{
    public interface IAdminService
    {
        Task<AdminDto?> GetAdminByIdAsync(int id);
        Task<Admin?> GetAdminByEmailAsync(string email);
        Task<AdminDto?> CreateAdminAsync(AdminCreateDto admin);
    }
}
