using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models.DTOs.Customer;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();

                if (customers.IsNullOrEmpty())
                {
                    return NotFound("No customers in database.");
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                return Ok(customer);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }


        [HttpGet("email/{email}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerByMail(string email)
        {
            try
            {
                var customer = await _customerService.GetCustomerByEmailAsync(email);
                return Ok(customer);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }



        [HttpPost("create")]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerCreateDto customerCreateDto)
        {
            try
            {
                var createdCustomer = await _customerService.CreateCustomerAsync(customerCreateDto);

                var locationUrl = Url.Action(nameof(GetCustomerById), new { id = createdCustomer.CustomerId });

                // Log URL for debugging
                _logger.LogInformation("Redirecting to: {LocationUrl}", locationUrl);

                return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerId }, createdCustomer);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }


        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDto>> UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (id != customerDto.CustomerId)
            {
                return ResponseHelper.HandleBadRequest(_logger, "Customer ID mismatch. Make sure ID matches in both URL and request body.");
            }
            try
            {
                var updatedCustomer = await _customerService.UpdateCustomerAsync(customerDto);
                return Ok(updatedCustomer);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDto>> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return ResponseHelper.HandleSuccess(_logger, $"Customer with ID {id} has been successfully deleted.");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }
    }
}