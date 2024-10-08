﻿using AutoMapper;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs.TimeSlot;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly IOpeningHoursService _openingHoursService;
        private readonly IOpeningHoursRepository _openingHoursRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TimeSlotService(
            ITimeSlotRepository timeSlotRepository,
            IOpeningHoursService openingHoursService,
            IOpeningHoursRepository openingHoursRepository,
            ITableRepository tableRepository,
            IMapper mapper)
        {
            _timeSlotRepository = timeSlotRepository;
            _openingHoursService = openingHoursService;
            _openingHoursRepository = openingHoursRepository;
            _tableRepository = tableRepository;
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

            if (timeSlot == null)
            {
                throw new KeyNotFoundException($"TimeSlot with ID {id} not found.");
            }

            return _mapper.Map<TimeSlotDto>(timeSlot);
        }


        public async Task<IEnumerable<TimeSlotDto>> GetTimeSlotsByIds(List<int> ids)
        {
            var timeSlots = await _timeSlotRepository.GetTimeSlotsByIds(ids);
            return _mapper.Map<IEnumerable<TimeSlotDto>>(timeSlots);
        }



        public async Task<IEnumerable<TimeSlotDto>> GetTimeSlotsByDateAsync(DateTime date)
        {
            var timeSlots = await _timeSlotRepository.GetTimeSlotsByDateAsync(date);
            return _mapper.Map<IEnumerable<TimeSlotDto>>(timeSlots);
        }



        public async Task<IEnumerable<TimeSlotDto>> GetTimeSlotsForWeekAsync(DateTime chosenDate)
        {
            // Calculate the start and end of the week (assuming the week starts on Monday)
            var startOfWeek = chosenDate.Date.AddDays(-(int)chosenDate.DayOfWeek + (int)DayOfWeek.Monday);
            var endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1); // End of the week is Sunday 23:59:59

            var timeSlots = await _timeSlotRepository.GetTimeSlotsForDateRangeAsync(startOfWeek, endOfWeek);
            return _mapper.Map<IEnumerable<TimeSlotDto>>(timeSlots);
        }




        public async Task<IEnumerable<TimeSlotDto>> GetTimeSlotsByTablesAsync(IEnumerable<int> tableIds)
        {
            var timeSlots = await _timeSlotRepository.GetTimeSlotsByTableIdsAsync(tableIds);
            return timeSlots.Select(ts => new TimeSlotDto
            {
                TimeSlotId = ts.TimeSlotId,
                StartTime = ts.StartTime,
                EndTime = ts.EndTime,
                TableId = ts.TableId,
            });
        }

        public async Task<IEnumerable<TimeSlotDto>> AutoGenerateTimeSlots(TimeSlotAutoGenerateDto timeSlotAutoGenerateDto)
        {
            if (timeSlotAutoGenerateDto.EndDate <= timeSlotAutoGenerateDto.StartDate)
            {
                throw new InvalidOperationException("End date must be after the start date.");
            }

            var allGeneratedTimeSlots = new List<TimeSlot>();
            var existingTimeSlots = await _timeSlotRepository.GetAllTimeSlots(); // Fetch all time slots to avoid duplicates
            var tables = await _tableRepository.GetAllAsync();

            // Fetch all opening hours for the week from the database
            IEnumerable<OpeningHours> openingHoursList = await _openingHoursRepository.GetAllAsync();
            var openingHoursLookup = openingHoursList.ToDictionary(oh => oh.DayOfWeek);

            // Special opening hours lookup
            var specialOpeningHoursLookup = openingHoursList
                .SelectMany(oh => oh.SpecialOpeningHours)
                .ToDictionary(soh => soh.Date, soh => soh);

            var currentDay = timeSlotAutoGenerateDto.StartDate;

            while (currentDay <= timeSlotAutoGenerateDto.EndDate)
            {
                var dayOfWeek = currentDay.DayOfWeek;

                if (openingHoursLookup.TryGetValue(dayOfWeek, out var openingHours))
                {
                    var specialOpeningHours = specialOpeningHoursLookup.GetValueOrDefault(DateOnly.FromDateTime(currentDay));

                    var openTime = specialOpeningHours?.OpenTime ?? openingHours.OpenTime;
                    var closeTime = specialOpeningHours?.CloseTime ?? openingHours.CloseTime;
                    var isClosed = specialOpeningHours?.IsClosed ?? openingHours.IsClosed;

                    if (!isClosed)
                    {
                        foreach (var table in tables)
                        {
                            var generatedTimeSlots = GenerateTimeSlotsForDayAndTable(openingHours, table, openTime, closeTime, timeSlotAutoGenerateDto.SlotDuration, currentDay, timeSlotAutoGenerateDto.EndDate);
                            allGeneratedTimeSlots.AddRange(generatedTimeSlots);
                        }
                    }
                }

                currentDay = currentDay.AddDays(1); // Move to the next day
            }

            var newTimeSlots = allGeneratedTimeSlots
                .Where(ts => !existingTimeSlots.Any(existingTs => existingTs.StartTime == ts.StartTime && existingTs.EndTime == ts.EndTime && existingTs.TableId == ts.TableId))
                .ToList();

            if (newTimeSlots.Any())
            {
                await _timeSlotRepository.AddMultipleTimeSlots(newTimeSlots);
            }
            else
            {
                throw new InvalidOperationException("Timeslots already created for the chosen period.");
            }

            return newTimeSlots.Select(ts => new TimeSlotDto
            {
                TimeSlotId = ts.TimeSlotId,
                StartTime = ts.StartTime,
                EndTime = ts.EndTime,
                TableId = ts.TableId,
            }).ToList();
        }

        private List<TimeSlot> GenerateTimeSlotsForDayAndTable(
            OpeningHours openingHours,
            Table table,
            TimeOnly openTime,
            TimeOnly closeTime,
            int slotDuration,
            DateTime startDate,
            DateTime endDate)
        {
            var timeSlots = new List<TimeSlot>();
            var currentTime = openTime;
            var isNextDay = false;

            while (!isNextDay && currentTime.AddMinutes(slotDuration) <= closeTime)
            {
                var startDateTime = startDate.Date.Add(currentTime.ToTimeSpan());
                var endDateTime = startDate.Date.Add(currentTime.AddMinutes(slotDuration).ToTimeSpan());

                // Check if we've wrapped around to the next day
                if (endDateTime < startDateTime)
                {
                    isNextDay = true;
                    endDateTime = endDateTime.AddDays(1);
                }

                if (endDateTime <= endDate)
                {
                    var timeSlot = new TimeSlot
                    {
                        StartTime = startDateTime,
                        EndTime = endDateTime,
                        OpeningHoursId = openingHours.OpeningHoursId,
                        TableId = table.TableId
                    };
                    timeSlots.Add(timeSlot);
                }

                currentTime = currentTime.AddMinutes(15);

                // Check if we've wrapped around to the next day
                if (currentTime < openTime)
                {
                    isNextDay = true;
                }
            }

            return timeSlots;
        }
        public async Task<TimeSlotDto> CreateTimeSlotAsync(TimeSlotCreateDto timeSlotCreateDto)
        {
            var timeSlot = _mapper.Map<TimeSlot>(timeSlotCreateDto);
            DayOfWeek dayOfWeek = timeSlot.StartTime.DayOfWeek;

            // Check if the time slot falls within valid opening hours
            var openingHours = await _openingHoursRepository.GetAllAsync();
            var matchingOpeningHours = openingHours.FirstOrDefault(o => o.DayOfWeek == dayOfWeek);
            if (matchingOpeningHours == null)
            {
                throw new Exception($"No OpeningHours found for the day: {dayOfWeek}");
            }

            timeSlot.OpeningHoursId = matchingOpeningHours.OpeningHoursId;

            // Check for overlapping timeslots
            var existingTimeSlots = await _timeSlotRepository.GetTimeSlotsByTableIdsAsync(new List<int> { timeSlot.TableId });
            bool hasConflict = existingTimeSlots.Any(ts =>
                (ts.StartTime < timeSlot.EndTime && ts.EndTime > timeSlot.StartTime));

            if (hasConflict)
            {
                throw new InvalidOperationException("The requested timeslot conflicts with an existing timeslot.");
            }

            await _timeSlotRepository.AddTimeSlot(timeSlot);

            return _mapper.Map<TimeSlotDto>(timeSlot);
        }

        public async Task UpdateTimeSlotAsync(int id, TimeSlotUpdateDto timeSlotUpdateDto)
        {
            var timeSlot = await _timeSlotRepository.GetTimeSlotById(id);
            if (timeSlot == null)
            {
                throw new KeyNotFoundException($"TimeSlot with ID {id} not found.");
            }

            // Update time slot fields
            _mapper.Map(timeSlotUpdateDto, timeSlot);

            // Check if the new time slot's opening hours are still valid
            var dayOfWeek = timeSlot.StartTime.DayOfWeek;
            var openingHours = await _openingHoursRepository.GetAllAsync();
            var matchingOpeningHours = openingHours.FirstOrDefault(o => o.DayOfWeek == dayOfWeek);

            if (matchingOpeningHours == null)
            {
                throw new Exception($"No OpeningHours found for the day: {dayOfWeek}");
            }

            timeSlot.OpeningHoursId = matchingOpeningHours.OpeningHoursId;
            await _timeSlotRepository.UpdateTimeSlot(timeSlot);
        }

        public async Task DeleteTimeSlotAsync(int id)
        {
            var timeSlotToDelete = await _timeSlotRepository.GetTimeSlotById(id);
            if (timeSlotToDelete == null)
            {
                throw new KeyNotFoundException($"No timeslot with ID {id} exists in database.");
            }

            await _timeSlotRepository.DeleteTimeSlot(timeSlotToDelete);
        }
    }
}
