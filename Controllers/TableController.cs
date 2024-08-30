using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Controllers
{
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

        [HttpGet("{id}")]
        public async Task<ActionResult<TableDto>> GetTableById(int id)
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

        [HttpPost("create")]
        public async Task<ActionResult<TableDto>> CreateTableAsync(TableCreateDto tableCreateDto)
        {
            try
            {
                var createdTable = await _tableService.CreateTableAsync(tableCreateDto);

                var locationUrl = Url.Action(nameof(GetTableById), new { id = createdTable.TableId });

                // Log the URL for debugging purposes
                _logger.LogInformation("Redirecting to: {LocationUrl}", locationUrl);

                return CreatedAtAction(nameof(GetTableById), new { id = createdTable.TableId }, createdTable);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TableDto>> UpdateTableAsync(int id, TableCreateDto tableCreateDto)
        {
            try
            {
                var updatedTable = await _tableService.UpdateTableAsync(id, tableCreateDto);

                return CreatedAtAction(nameof(GetTableById), new { id = updatedTable.TableId }, updatedTable);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<TableDto>> DeleteTableAsync(int id)
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
}