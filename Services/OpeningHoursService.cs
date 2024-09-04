using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations.Services
{
    public class OpeningHoursService : IOpeningHoursService
    {
        private readonly IOpeningHoursRepository _openingHoursRepository;

        public OpeningHoursService(IOpeningHoursRepository openingHoursRepository)
        {
            _openingHoursRepository = openingHoursRepository;
        }

        public async Task<IEnumerable<OpeningHoursDto>> GetAllOpeningHoursAsync()
        {
            var openingHours = await _openingHoursRepository.GetAllAsync();
            return openingHours.Select(o => new OpeningHoursDto
            {
                OpeningHoursId = o.OpeningHoursId,
                DayOfWeek = o.DayOfWeek,
                OpenTime = o.OpenTime,
                CloseTime = o.CloseTime,
                IsClosed = o.IsClosed,
                SpecialOpeningHours = o.SpecialOpeningHours.Select(s => new SpecialOpeningHoursDto
                {
                    SpecialOpeningHoursId = s.SpecialOpeningHoursId,
                    Date = s.Date,
                    OpenTime = s.OpenTime,
                    CloseTime = s.CloseTime,
                    IsClosed = s.IsClosed,
                    OpeningHoursId = s.OpeningHoursId // Ensure foreign key is included
                }).ToList(),
                TimeSlots = o.TimeSlots.Select(t => new TimeSlotDto
                {
                    TimeSlotId = t.TimeSlotId,
                    StartTime = t.StartTime,
                    EndTime = t.EndTime,
                    SlotDuration = t.SlotDuration
                }).ToList()
            }).ToList();
        }

        public async Task<OpeningHoursDto?> GetOpeningHoursByIdAsync(int id)
        {
            var openingHours = await _openingHoursRepository.GetByIdAsync(id);
            if (openingHours == null)
            {
                return null;
            }

            return new OpeningHoursDto
            {
                OpeningHoursId = openingHours.OpeningHoursId,
                DayOfWeek = openingHours.DayOfWeek,
                OpenTime = openingHours.OpenTime,
                CloseTime = openingHours.CloseTime,
                IsClosed = openingHours.IsClosed,
                SpecialOpeningHours = openingHours.SpecialOpeningHours.Select(s => new SpecialOpeningHoursDto
                {
                    SpecialOpeningHoursId = s.SpecialOpeningHoursId,
                    Date = s.Date,
                    OpenTime = s.OpenTime,
                    CloseTime = s.CloseTime,
                    IsClosed = s.IsClosed,
                    OpeningHoursId = s.OpeningHoursId // Ensure foreign key is included
                }).ToList(),
                TimeSlots = openingHours.TimeSlots.Select(t => new TimeSlotDto
                {
                    TimeSlotId = t.TimeSlotId,
                    StartTime = t.StartTime,
                    EndTime = t.EndTime,
                    SlotDuration = t.SlotDuration
                }).ToList()
            };
        }

        public async Task<OpeningHoursDto> CreateOpeningHoursAsync(OpeningHoursCreateDto openingHoursCreateDto)
        {
            var openingHours = new OpeningHours
            {
                DayOfWeek = openingHoursCreateDto.DayOfWeek,
                OpenTime = openingHoursCreateDto.OpenTime,
                CloseTime = openingHoursCreateDto.CloseTime,
                IsClosed = openingHoursCreateDto.IsClosed,
                SpecialOpeningHours = openingHoursCreateDto.SpecialOpeningHours.Select(s => new SpecialOpeningHours
                {
                    Date = s.Date,
                    OpenTime = s.OpenTime,
                    CloseTime = s.CloseTime,
                    IsClosed = s.IsClosed,
                    OpeningHoursId = s.OpeningHoursId // Ensure foreign key is set
                }).ToList()
            };

            await _openingHoursRepository.AddAsync(openingHours);

            return new OpeningHoursDto
            {
                OpeningHoursId = openingHours.OpeningHoursId,
                DayOfWeek = openingHours.DayOfWeek,
                OpenTime = openingHours.OpenTime,
                CloseTime = openingHours.CloseTime,
                IsClosed = openingHours.IsClosed,
                SpecialOpeningHours = openingHours.SpecialOpeningHours.Select(s => new SpecialOpeningHoursDto
                {
                    SpecialOpeningHoursId = s.SpecialOpeningHoursId,
                    Date = s.Date,
                    OpenTime = s.OpenTime,
                    CloseTime = s.CloseTime,
                    IsClosed = s.IsClosed,
                    OpeningHoursId = s.OpeningHoursId // Ensure foreign key is included
                }).ToList()
            };
        }

        public async Task<OpeningHoursDto> UpdateOpeningHoursAsync(OpeningHoursDto openingHoursDto)
        {
            var existingOpeningHours = await _openingHoursRepository.GetByIdAsync(openingHoursDto.OpeningHoursId);
            if (existingOpeningHours == null)
            {
                throw new KeyNotFoundException($"Opening hours with ID {openingHoursDto.OpeningHoursId} not found.");
            }

            existingOpeningHours.DayOfWeek = openingHoursDto.DayOfWeek;
            existingOpeningHours.OpenTime = openingHoursDto.OpenTime;
            existingOpeningHours.CloseTime = openingHoursDto.CloseTime;
            existingOpeningHours.IsClosed = openingHoursDto.IsClosed;

            // Update SpecialOpeningHours
            existingOpeningHours.SpecialOpeningHours.Clear();
            existingOpeningHours.SpecialOpeningHours = openingHoursDto.SpecialOpeningHours.Select(s => new SpecialOpeningHours
            {
                SpecialOpeningHoursId = s.SpecialOpeningHoursId,
                Date = s.Date,
                OpenTime = s.OpenTime,
                CloseTime = s.CloseTime,
                IsClosed = s.IsClosed,
                OpeningHoursId = s.OpeningHoursId // Ensure foreign key is set
            }).ToList();

            await _openingHoursRepository.UpdateAsync(existingOpeningHours);

            return new OpeningHoursDto
            {
                OpeningHoursId = existingOpeningHours.OpeningHoursId,
                DayOfWeek = existingOpeningHours.DayOfWeek,
                OpenTime = existingOpeningHours.OpenTime,
                CloseTime = existingOpeningHours.CloseTime,
                IsClosed = existingOpeningHours.IsClosed,
                SpecialOpeningHours = existingOpeningHours.SpecialOpeningHours.Select(s => new SpecialOpeningHoursDto
                {
                    SpecialOpeningHoursId = s.SpecialOpeningHoursId,
                    Date = s.Date,
                    OpenTime = s.OpenTime,
                    CloseTime = s.CloseTime,
                    IsClosed = s.IsClosed,
                    OpeningHoursId = s.OpeningHoursId // Ensure foreign key is included
                }).ToList()
            };
        }

        public async Task DeleteOpeningHoursAsync(int id)
        {
            var openingHoursToDelete = await _openingHoursRepository.GetByIdAsync(id);
            if (openingHoursToDelete == null)
            {
                throw new KeyNotFoundException($"Opening hours with ID {id} not found.");
            }

            await _openingHoursRepository.DeleteAsync(openingHoursToDelete);
        }
    }
}