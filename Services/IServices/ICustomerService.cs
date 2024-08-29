using Reliable_Reservations.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reliable_Reservations.Services.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto?> GetCustomerByIdAsync(int id);
        Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto);
        Task<CustomerDto> UpdateCustomerAsync(CustomerDto customerDto);
        Task DeleteCustomerAsync(int id);
    }
}
