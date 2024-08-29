using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repositories.IRepos;
using Reliable_Reservations.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reliable_Reservations.Services
{
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

            List<CustomerDto> customerDtos = customers
                .Select(c => new CustomerDto()
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email
                })
                .ToList();

            return customerDtos;
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return null;
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

        public async Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto dto)
        {
            Customer newCustomer = new()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };

            await _customerRepository.AddAsync(newCustomer);

            CustomerDto customerDto = new()
            {
                CustomerId = newCustomer.CustomerId,
                FirstName = newCustomer.FirstName,
                LastName = newCustomer.LastName,
                PhoneNumber = newCustomer.PhoneNumber,
                Email = newCustomer.Email
            };

            return customerDto;
        }

        public async Task<CustomerDto> UpdateCustomerAsync(CustomerDto customerDto)
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

            var updatedCustomer = new CustomerDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email
            };

            return updatedCustomer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}