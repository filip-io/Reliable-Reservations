using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();

        var customerDtos = new List<CustomerDto>();
        foreach (var customer in customers)
        {
            customerDtos.Add(new CustomerDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email
            });
        }

        return customerDtos;
    }

    public async Task<CustomerDto> GetCustomerByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer == null)
        {
            throw new KeyNotFoundException($"Customer with ID {id} not found.");
        }

        return new CustomerDto
        {
            CustomerId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email
        };
    }

    public async Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
    {
        var customer = new Customer
        {
            FirstName = customerCreateDto.FirstName,
            LastName = customerCreateDto.LastName,
            PhoneNumber = customerCreateDto.PhoneNumber,
            Email = customerCreateDto.Email
        };

        await _customerRepository.AddAsync(customer);

        var customerDto = new CustomerDto
        {
            CustomerId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email
        };

        return customerDto;
    }

    public async Task UpdateCustomerAsync(CustomerDto customerDto)
    {
        var customer = await _customerRepository.GetByIdAsync(customerDto.CustomerId);

        if (customer == null)
        {
            throw new KeyNotFoundException($"Customer with ID {customerDto.CustomerId} not found.");
        }

        customer.FirstName = customerDto.FirstName;
        customer.LastName = customerDto.LastName;
        customer.PhoneNumber = customerDto.PhoneNumber;
        customer.Email = customerDto.Email;

        await _customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _customerRepository.DeleteAsync(id);
    }
}