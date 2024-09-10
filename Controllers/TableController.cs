using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models.DTOs.Table;
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
                var tableDto = await _tableService.GetTableByIdAsync(id);
                return Ok(tableDto);
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
        public async Task<ActionResult<TableDto>> CreateTableAsync(TableCreateDto tableCreateDto)
        {
            try
            {
                var newTable = await _tableService.CreateTableAsync(tableCreateDto);

                var locationUrl = Url.Action(nameof(GetTableById), new { id = newTable.TableId });

                // Log the URL for debugging purposes
                _logger.LogInformation("Redirecting to: {LocationUrl}", locationUrl);

                return CreatedAtAction(nameof(GetTableById), new { id = newTable.TableId }, newTable);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TableUpdateDto>> UpdateTableAsync(int id, TableUpdateDto tableUpdateDto)
        {
            if (id != tableUpdateDto.TableId)
            {
                return ResponseHelper.HandleBadRequest(_logger, "Table ID mismatch. Make sure ID matches in both URL and request body.");
            }
            try
            {
                var updatedTable = await _tableService.UpdateTableAsync(id, tableUpdateDto);
                return Ok(updatedTable);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<TableDto>> DeleteTableAsync(int id)
        {
            try
            {
                await _tableService.DeleteTableAsync(id);
                return Ok($"Table with ID {id} was successfully deleted.");
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