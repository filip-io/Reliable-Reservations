using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Reliable_Reservations.Data;
using Reliable_Reservations.Models;
using Reliable_Reservations.Repositories.IRepos;

namespace Reliable_Reservations.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly ReliableReservationsDbContext _context;

        public TableRepository(ReliableReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Table>> GetAllAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table?> GetByIdAsync(int id)
        {
            return await _context.Tables.FindAsync(id);
        }

        public async Task<bool> TableNumberExistsAsync(int tableNumber)
        {
            return await _context.Tables.AnyAsync(t => t.TableNumber == tableNumber);
        }

        public async Task<List<Table>> GetTablesByNumbersAsync(List<int> tableNumbers)
        {
            // If no table numbers provided, return empty list to avoid unnecessary db query.
            if (tableNumbers == null || !tableNumbers.Any())
            {
                return new List<Table>();
            }

            return await _context.Tables
                .Where(t => tableNumbers.Contains(t.TableNumber))
                .ToListAsync();
        }

        public async Task AddAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table != null)
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
        }
    }
}