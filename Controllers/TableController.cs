using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Services.IServices;

[ApiController]
[Route("api/[controller]")]
public class TableController : ControllerBase
{
    private readonly ITableService _tableService;
    private readonly ILogger<TableController> _logger;

    public TableController(ITableService tableService, ILogger<TableController> logger)
    {
        _tableService = tableService;
        _logger = logger;
    }

    // GET: api/Table/all
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<TableDto>>> GetAllTablesAsync()
    {
        try
        {
            var tables = await _tableService.GetAllTablesAsync();

            if (tables.IsNullOrEmpty())
            {
                return Ok("No tables in database.");
            }
            else
            {
                return Ok(tables);
            }
        }
        catch (Exception ex)
        {
            return ResponseHelper.HandleException(_logger, ex);
        }
    }

    // GET: api/Table/get/{id}
    [HttpGet("get/{id}")]
    public async Task<ActionResult<TableDto>> GetTableByIdAsync(int id)
    {
        try
        {
            var table = await _tableService.GetTableByIdAsync(id);
            if (table == null)
            {
                return ResponseHelper.HandleNotFound(_logger, id);
            }
            return Ok(table);
        }
        catch (Exception ex)
        {
            return ResponseHelper.HandleException(_logger, ex);
        }
    }

    // POST: api/Table/create
    [HttpPost("create")]
    public async Task<ActionResult<TableDto>> CreateTableAsync(TableCreateDto tableCreateDto)
    {
        try
        {
            var createdTable = await _tableService.CreateTableAsync(tableCreateDto);
            return CreatedAtAction(nameof(GetTableByIdAsync), new { id = createdTable.TableId }, createdTable);
        }
        catch (Exception ex)
        {
            return ResponseHelper.HandleException(_logger, ex);
        }
    }

    // PUT: api/Table/update/{id}
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTableAsync(int id, TableCreateDto tableCreateDto)
    {
        try
        {
            await _tableService.UpdateTableAsync(id, tableCreateDto);
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

    // DELETE: api/Table/delete/{id}
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteTableAsync(int id)
    {
        try
        {
            await _tableService.DeleteTableAsync(id);
            return Ok($"Table with ID {id} was successfully deleted.");
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