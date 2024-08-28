﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Reliable_Reservations.Data;
using Reliable_Reservations.Models;
using Reliable_Reservations.Repositories.Interfaces;

namespace Reliable_Reservations.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly ReliableReservationsDbContext _context;

        public TableRepository(ReliableReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table?> GetTableByIdAsync(int id)
        {
            return await _context.Tables.FindAsync(id);
        }

        public async Task<bool> TableNumberExistsAsync(int tableNumber)
        {
            return await _context.Tables.AnyAsync(t => t.TableNumber == tableNumber);
        }

        public async Task AddTableAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int id)
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