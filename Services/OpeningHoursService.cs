using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repositories.IRepos;
using Reliable_Reservations.Services.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reliable_Reservations.Services
{
    public class OpeningHoursService : IOpeningHoursService
    {
        private readonly IOpeningHoursRepository _openingHoursRepository;
        private readonly IMapper _mapper;

        public OpeningHoursService(IOpeningHoursRepository openingHoursRepository, IMapper mapper)
        {
            _openingHoursRepository = openingHoursRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OpeningHoursDto>> GetAllOpeningHoursAsync()
        {
            var openingHours = await _openingHoursRepository.GetAllAsync();
            return openingHours.Select(oh => _mapper.Map<OpeningHoursDto>(oh));
        }

        public async Task<OpeningHoursDto?> GetOpeningHoursByIdAsync(int id)
        {
            var openingHours = await _openingHoursRepository.GetByIdAsync(id);
            return openingHours == null ? null : _mapper.Map<OpeningHoursDto>(openingHours);
        }

        public async Task<OpeningHoursDto> CreateOpeningHoursAsync(OpeningHoursCreateDto openingHoursCreateDto)
        {
            var openingHours = _mapper.Map<OpeningHours>(openingHoursCreateDto);
            await _openingHoursRepository.AddAsync(openingHours);
            return _mapper.Map<OpeningHoursDto>(openingHours);
        }

        public async Task<OpeningHoursDto> UpdateOpeningHoursAsync(OpeningHoursDto openingHoursDto)
        {
            var existingOpeningHours = await _openingHoursRepository.GetByIdAsync(openingHoursDto.OpeningHoursId);
            if (existingOpeningHours == null)
            {
                throw new KeyNotFoundException($"Opening hours with ID {openingHoursDto.OpeningHoursId} not found.");
            }

            var openingHoursToUpdate = _mapper.Map<OpeningHours>(openingHoursDto);
            await _openingHoursRepository.UpdateAsync(openingHoursToUpdate);
            return _mapper.Map<OpeningHoursDto>(openingHoursToUpdate);
        }

        public async Task DeleteOpeningHoursAsync(int id)
        {
            await _openingHoursRepository.DeleteAsync(id);
        }
    }
}