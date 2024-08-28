using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repositories.Interfaces;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TableDto>> GetAllTablesAsync()
        {
            var tables = await _tableRepository.GetAllTablesAsync();
            return _mapper.Map<IEnumerable<TableDto>>(tables);
        }

        public async Task<TableDto> GetTableByIdAsync(int id)
        {
            var table = await _tableRepository.GetTableByIdAsync(id);

            if (table == null)
            {
                throw new KeyNotFoundException($"Table with ID {id} not found.");
            }
            else
            {
                return _mapper.Map<TableDto>(table);
            }
        }

        public async Task<TableDto> CreateTableAsync(TableCreateDto tableCreateDto)
        {
            if (await _tableRepository.TableNumberExistsAsync(tableCreateDto.TableNumber))
            {
                throw new InvalidOperationException($"Table number {tableCreateDto.TableNumber} is already in use.");
            }

            var table = _mapper.Map<Table>(tableCreateDto);
            await _tableRepository.AddTableAsync(table);
            return _mapper.Map<TableDto>(table);
        }

        public async Task UpdateTableAsync(int id, TableCreateDto tableCreateDto)
        {
            var table = await _tableRepository.GetTableByIdAsync(id);
            if (table == null) throw new KeyNotFoundException($"No table with ID {id} found.");

            _mapper.Map(tableCreateDto, table);
            await _tableRepository.UpdateTableAsync(table);
        }

        public async Task DeleteTableAsync(int id)
        {
            await _tableRepository.DeleteTableAsync(id);
        }
    }
}