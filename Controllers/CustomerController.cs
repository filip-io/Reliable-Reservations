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
            return ResponseHelper.HandleException(_logger, ex);
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
                return ResponseHelper.HandleNotFound(_logger, id);
            }

            return Ok(customer);
        }
        catch (Exception ex)
        {
            return ResponseHelper.HandleException(_logger, ex);
        }
    }

    // POST: api/Customer/create
    [HttpPost("create")]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerCreateDto customerCreateDto)
    {
        try
        {
            var createdCustomer = await _customerService.CreateCustomerAsync(customerCreateDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerId }, createdCustomer);
        }
        catch (Exception ex)
        {
            return ResponseHelper.HandleException(_logger, ex);
        }
    }

    // PUT: api/Customer/update/{id}
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customerDto)
    {
        if (id != customerDto.CustomerId)
        {
            return ResponseHelper.HandleBadRequest(_logger, "Customer ID mismatch. Make sure ID matches in both URL and request body.");
        }
        try
        {
            await _customerService.UpdateCustomerAsync(customerDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return ResponseHelper.HandleNotFound(_logger, id);
        }
        catch (Exception ex)
        {
            return ResponseHelper.HandleException(_logger, ex);
        }
    }

    // DELETE: api/Customer/delete/{id}
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        try
        {
            await _customerService.DeleteCustomerAsync(id);
            return ResponseHelper.HandleSuccess(_logger, $"Customer with ID {id} has been successfully deleted.");
        }
        catch (KeyNotFoundException)
        {
            return ResponseHelper.HandleNotFound(_logger, id);
        }
        catch (Exception ex)
        {
            return ResponseHelper.HandleException(_logger, ex);
        }
    }
}