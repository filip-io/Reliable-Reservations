using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data;
using Reliable_Reservations.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CustomerRepository : ICustomerRepository
{
    private readonly ReliableReservationsDbContext _context;

    public CustomerRepository(ReliableReservationsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        var existingCustomer = await _context.Customers.FindAsync(customer.CustomerId);
        if (existingCustomer == null)
        {
            throw new KeyNotFoundException($"Customer with ID {customer.CustomerId} not found.");
        }

        // Only update changed values for efficiency and optimization
        _context.Entry(existingCustomer).CurrentValues.SetValues(customer);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException($"Customer with ID {id} not found.");
        }
    }
}