using AutoMapper;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
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
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto dto)
        {
            var newCustomer = _mapper.Map<Customer>(dto);
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

            _mapper.Map(customerDto, customer);

            await _customerRepository.UpdateAsync(customer);

            var updatedCustomerDto = _mapper.Map<CustomerDto>(customer);

            return updatedCustomerDto;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            await _customerRepository.DeleteAsync(customer);
        }
    }
}