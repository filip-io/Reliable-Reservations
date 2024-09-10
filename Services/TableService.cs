using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs.Table;
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
            var tables = await _tableRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TableDto>>(tables);
        }

        public async Task<TableDto?> GetTableByIdAsync(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);

            if (table == null)
            {
                return null;
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
            await _tableRepository.AddAsync(table);
            return _mapper.Map<TableDto>(table);
        }

        public async Task<TableDto> UpdateTableAsync(int id, TableUpdateDto tableUpdateDto)
        {
            var table = await _tableRepository.GetByIdAsync(id);

            if (table == null)
            {
                throw new KeyNotFoundException($"No table with ID {id} found.");
            }

            _mapper.Map(tableUpdateDto, table);
            await _tableRepository.UpdateAsync(table);
            return _mapper.Map<TableDto>(table);
        }

        public async Task DeleteTableAsync(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);

            if (table == null)
            {
                throw new KeyNotFoundException($"Table with {id} not found.");
            }

            await _tableRepository.DeleteAsync(table);
        }
    }
}