using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data.Repos
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ReliableReservationsDbContext _context;

        public AdminRepository(ReliableReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<Admin?> GetAdminByIdAsync(int id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task<Admin?> GetAdminByEmailAsync(string email)
        {
            return await _context.Admins.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> AdminExistsAsync(string email)
        {
            return await _context.Admins.AnyAsync(u => u.Email == email);
        }

        public async Task AddAdminAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }
    }
}
