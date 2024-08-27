using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
    {
        _customerService = customerService;
        _logger = logger;
    }

    // GET: api/Customer/all
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
    {
        try
        {
            var customers = await _customerService.GetAllCustomersAsync();

            if (customers.IsNullOrEmpty())
            {
                return Ok("No customers in database.");
            }
            else
            {
                return Ok(customers);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all customers.");
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    // GET: api/Customer/get/{id}
    [HttpGet("get/{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
    {
        try
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                _logger.LogWarning("Customer with ID {id} not found.", id);
                return NotFound($"Customer with ID {id} not found.");
            }

            return Ok(customer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while getting customer with ID {id}.");
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    // POST: api/Customer/create
    [HttpPost("create")]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerDto customerDto)
    {
        try
        {
            var createdCustomer = await _customerService.CreateCustomerAsync(customerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerId }, createdCustomer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating a customer.");
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    // PUT: api/Customer/update/{id}
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customerDto)
    {
        if (id != customerDto.CustomerId)
        {
            return BadRequest("Customer ID mismatch.");
        }

        try
        {
            await _customerService.UpdateCustomerAsync(customerDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            _logger.LogWarning("Customer with ID {id} not found.", id);
            return NotFound($"Customer with ID {id} not found.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating customer with ID {id}.");
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    // DELETE: api/Customer/delete/{id}
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        try
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            _logger.LogWarning("Customer with ID {id} not found.", id);
            return NotFound($"Customer with ID {id} not found.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while deleting customer with ID {id}.");
            return StatusCode(500, "An unexpected error occurred.");
        }
    }
}