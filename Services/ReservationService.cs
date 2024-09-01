using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repos.IRepos;
using Reliable_Reservations.Repositories;
using Reliable_Reservations.Repositories.IRepos;
using Reliable_Reservations.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reliable_Reservations.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;
        private readonly ITimeSlotService _timeSlotService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOpeningHoursRepository _openingHoursRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ReservationService> _logger;

        public ReservationService(
            IReservationRepository reservationRepository,
            ITableRepository tableRepository,
            ITimeSlotService timeSlotService,
            ICustomerRepository customerRepository,
            IOpeningHoursRepository openingHoursRepository,
            IMapper mapper,
            ILogger<ReservationService> logger)
        {
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
            _timeSlotService = timeSlotService;
            _customerRepository = customerRepository;
            _openingHoursRepository = openingHoursRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ReservationDto>> GetAllReservationsAsync()
        {
            var reservations = await _reservationRepository.GetAllReservations();
            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }

        public async Task<ReservationDto?> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _reservationRepository.GetReservationById(reservationId);
            return _mapper.Map<ReservationDto?>(reservation);
        }

        public async Task<ReservationDto> CreateReservationAsync(ReservationCreateDto reservationCreateDto)
        {
            // Check if the reservation is in the past
            if (reservationCreateDto.ReservationDate < DateTime.Now)
            {
                throw new ArgumentException("Reservations cannot be made for past dates and times.");
            }

            // Check if the customer exists
            if (!await _customerRepository.CustomerExists(reservationCreateDto.CustomerId))
            {
                throw new ArgumentException("Customer does not exist.");
            }

            // Validate the reservation time against opening hours
            await ValidateReservationTimeAsync(reservationCreateDto.ReservationDate, reservationCreateDto.SeatingDuration);

            // Check if the selected tables are valid
            var selectedTables = await _tableRepository.GetTablesByNumbersAsync(reservationCreateDto.TableNumbers);
            if (selectedTables.Count != reservationCreateDto.TableNumbers.Count)
            {
                throw new ArgumentException("One or more table numbers are invalid.");
            }

            // Check if the seating capacity is sufficient
            int totalSeatingCapacity = selectedTables.Sum(table => table.SeatingCapacity);
            if (totalSeatingCapacity < reservationCreateDto.NumberOfGuests)
            {
                throw new InvalidOperationException($"The selected tables cannot accommodate {reservationCreateDto.NumberOfGuests} guests. The total seating capacity is {totalSeatingCapacity}.");
            }

            // Check if the selected tables are available
            var startTime = reservationCreateDto.ReservationDate;
            var endTime = startTime.AddMinutes(reservationCreateDto.SeatingDuration);
            var isAvailable = await AreTablesAvailableAsync(selectedTables, startTime, endTime);
            if (!isAvailable)
            {
                throw new InvalidOperationException("One or more tables are not available for the selected time slot.");
            }

            // Create the time slot using TimeSlotCreateDto
            TimeSlotDto timeSlotDto;
            try
            {
                var timeSlotCreateDto = new TimeSlotCreateDto
                {
                    StartTime = startTime,
                    EndTime = endTime
                };

                timeSlotDto = await _timeSlotService.CreateTimeSlotAsync(timeSlotCreateDto);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to create time slot: " + ex.Message);
            }

            // Create the reservation
            var reservation = new Reservation
            {
                CustomerId = reservationCreateDto.CustomerId,
                TimeSlotId = timeSlotDto.TimeSlotId, // Use the TimeSlotId from the created TimeSlot
                ReservationDate = reservationCreateDto.ReservationDate,
                NumberOfGuests = reservationCreateDto.NumberOfGuests,
                SpecialRequests = reservationCreateDto.SpecialRequests,
                Status = ReservationStatus.Pending,
                Tables = selectedTables
            };

            await _reservationRepository.AddReservation(reservation);

            return _mapper.Map<ReservationDto>(reservation);
        }

        private async Task ValidateReservationTimeAsync(DateTime reservationDate, int seatingDuration)
        {
            // Get the opening hours for the day of the week
            var dayOfWeek = reservationDate.DayOfWeek;
            var openingHours = await _openingHoursRepository.GetOpeningHoursByDateAsync(reservationDate);

            if (openingHours == null || openingHours.IsClosed)
            {
                throw new InvalidOperationException("The restaurant is closed on the selected date.");
            }

            // Adjust for special opening hours if any
            var specialOpeningHours = openingHours.SpecialOpeningHours
                .FirstOrDefault(soh => soh.Date == DateOnly.FromDateTime(reservationDate));

            TimeOnly openTime, closeTime;
            if (specialOpeningHours != null)
            {
                openTime = specialOpeningHours.OpenTime ?? openingHours.OpenTime;
                closeTime = specialOpeningHours.CloseTime ?? openingHours.CloseTime;
                if (specialOpeningHours.IsClosed)
                {
                    throw new InvalidOperationException("The restaurant is closed on the selected date.");
                }
            }
            else
            {
                openTime = openingHours.OpenTime;
                closeTime = openingHours.CloseTime;
            }

            var reservationStart = TimeOnly.FromDateTime(reservationDate);
            var reservationEnd = reservationStart.AddMinutes(seatingDuration);

            // Validate if the reservation is within opening hours
            if (reservationStart < openTime || reservationEnd > closeTime)
            {
                throw new InvalidOperationException("The reservation time is outside the restaurant's opening hours.");
            }
        }

        public async Task<bool> AreTablesAvailableAsync(List<Table> tables, DateTime startTime, DateTime endTime)
        {
            // Get all reservations for these tables within the time range
            var reservations = await _reservationRepository.GetReservationsForTablesAsync(tables, startTime, endTime);

            // Check for overlaps
            return !reservations.Any(r => IsOverlap(r.TimeSlot.StartTime, r.TimeSlot.EndTime, startTime, endTime));
        }

        private bool IsOverlap(DateTime existingStartTime, DateTime existingEndTime, DateTime newStartTime, DateTime newEndTime)
        {
            // Check if there is an overlap
            return existingStartTime < newEndTime && existingEndTime > newStartTime;
        }

        public async Task<ReservationDto> UpdateReservationAsync(ReservationDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
            var updatedReservation = await _reservationRepository.UpdateReservation(reservation);
            return _mapper.Map<ReservationDto>(updatedReservation);
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservationToDelete = await _reservationRepository.GetReservationById(reservationId);
            if (reservationToDelete == null)
            {
                throw new KeyNotFoundException();
            }

            await _reservationRepository.DeleteReservation(reservationToDelete);
        }
    }
}