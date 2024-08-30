using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repos.IRepos;
using Reliable_Reservations.Repositories.IRepos;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly IOpeningHoursRepository _openingHoursRepository;
        private readonly IMapper _mapper;

        public TimeSlotService(ITimeSlotRepository timeSlotRepository, IOpeningHoursRepository openingHoursRepository, IMapper mapper)
        {
            _timeSlotRepository = timeSlotRepository;
            _openingHoursRepository = openingHoursRepository;
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

            int timeSlotDuration = (int)(timeSlot.EndTime - timeSlot.StartTime).TotalMinutes;

            if (timeSlotDuration != 60 && timeSlotDuration != 120)
            {
                throw new Exception("TimeSlot duration must be either 60 or 120 minutes.");
            }

            timeSlot.SlotDuration = timeSlotDuration;

            DayOfWeek dayOfWeek = timeSlot.StartTime.DayOfWeek;
            var openingHours = await _openingHoursRepository.GetAllAsync();
            var matchingOpeningHours = openingHours.FirstOrDefault(o => o.DayOfWeek == dayOfWeek);

            if (matchingOpeningHours == null)
            {
                throw new Exception($"No OpeningHours found for the day: {dayOfWeek}");
            }

            timeSlot.OpeningHoursId = matchingOpeningHours.OpeningHoursId;

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
