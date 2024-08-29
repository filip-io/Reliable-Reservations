using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repos.IRepos;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly IMapper _mapper;

        public TimeSlotService(ITimeSlotRepository timeSlotRepository, IMapper mapper)
        {
            _timeSlotRepository = timeSlotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TimeSlotDto>> GetAllTimeSlotsAsync()
        {
            var timeSlots = await _timeSlotRepository.GetAllTimeSlots();
            return _mapper.Map<IEnumerable<TimeSlotDto>>(timeSlots);
        }

        public async Task<TimeSlotDto> GetTimeSlotByIdAsync(int id)
        {
            var timeSlot = await _timeSlotRepository.GetTimeSlotById(id);
            return _mapper.Map<TimeSlotDto>(timeSlot);
        }

        public async Task<TimeSlotDto> CreateTimeSlotAsync(TimeSlotCreateDto timeSlotCreateDto)
        {
            var timeSlot = _mapper.Map<TimeSlot>(timeSlotCreateDto);
            await _timeSlotRepository.AddTimeSlot(timeSlot);
            return _mapper.Map<TimeSlotDto>(timeSlot);
        }

        public async Task UpdateTimeSlotAsync(int id, TimeSlotCreateDto timeSlotCreateDto)
        {
            var timeSlot = await _timeSlotRepository.GetTimeSlotById(id);
            if (timeSlot != null)
            {
                _mapper.Map(timeSlotCreateDto, timeSlot);
                await _timeSlotRepository.UpdateTimeSlot(timeSlot);
            }
        }

        public async Task DeleteTimeSlotAsync(int id)
        {
            await _timeSlotRepository.DeleteTimeSlot(id);
        }
    }
}
