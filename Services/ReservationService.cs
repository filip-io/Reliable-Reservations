using AutoMapper;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;
using Reliable_Reservations.Services.IServices;
using Reliable_Reservations.Helpers;
using Reliable_Reservations.Models.DTOs.Reservation;
using Reliable_Reservations.Models.DTOs.TimeSlot;
using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data.Repos;

namespace Reliable_Reservations.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableService _tableService;
        private readonly ITableRepository _tableRepository;
        private readonly ITimeSlotService _timeSlotService;
        private readonly ITimeSlotRepository _timeSlotRepository; 
        private readonly ICustomerRepository _customerRepository;
        private readonly IOpeningHoursRepository _openingHoursRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ReservationService> _logger;

        public ReservationService(
            IReservationRepository reservationRepository,
            ITableService tableService,
            ITableRepository tableRepository,
            ITimeSlotService timeSlotService,
            ITimeSlotRepository timeSlotRepository,
            ICustomerRepository customerRepository,
            IOpeningHoursRepository openingHoursRepository,
            IMapper mapper,
            ILogger<ReservationService> logger)
        {
            _reservationRepository = reservationRepository;
            _tableService = tableService;
            _tableRepository = tableRepository;
            _timeSlotService = timeSlotService;
            _timeSlotRepository = timeSlotRepository;
            _customerRepository = customerRepository;
            _openingHoursRepository = openingHoursRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ReservationDetailsDto>> GetAllReservationsAsync()
        {
            var reservations = await _reservationRepository.GetAllReservations();
            return _mapper.Map<IEnumerable<ReservationDetailsDto>>(reservations);
        }

        public async Task<ReservationDetailsDto?> GetReservationByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetReservationById(id);

            if (reservation == null)
            {
                throw new KeyNotFoundException($"Reservation with ID {id} not found.");
            }

            return _mapper.Map<ReservationDetailsDto?>(reservation);
        }


        public async Task<IEnumerable<ReservationDetailsDto>> GetReservationsByDate(DateTime date)
        {
            return _mapper.Map<IEnumerable<ReservationDetailsDto>>(await _reservationRepository.GetReservationsByDate(date));
        }


        public async Task<ReservationDetailsDto> CreateReservationAsync(ReservationCreateDto reservationCreateDto)
        {
            if (reservationCreateDto.ReservationDate < DateTime.Now)
            {
                throw new ArgumentException("Reservations cannot be made for past dates and times.");
            }

            if (!await _customerRepository.CustomerExistsAsync(reservationCreateDto.CustomerId))
            {
                throw new ArgumentException("Customer does not exist.");
            }

            await ValidateReservationTimeAsync(reservationCreateDto.ReservationDate);

            // Fetch the selected tables
            var selectedTables = await _tableRepository.GetTablesByNumbersAsync(reservationCreateDto.TableNumbers);
            if (selectedTables.Count != reservationCreateDto.TableNumbers.Count)
            {
                throw new ArgumentException("One or more table numbers does not exist.");
            }

            int totalSeatingCapacity = selectedTables.Sum(table => table.SeatingCapacity);
            if (totalSeatingCapacity < reservationCreateDto.NumberOfGuests)
            {
                throw new InvalidOperationException($"The selected tables cannot accommodate {reservationCreateDto.NumberOfGuests} guests. The total seating capacity is {totalSeatingCapacity}.");
            }

            // Truncate the reservation date to minutes
            var reservationStart = Truncate.TruncateToMinutes(reservationCreateDto.ReservationDate);
            var reservationEnd = reservationStart.AddMinutes(90);


            // Check if the selected tables are available
            var isAvailable = await AreTablesAvailableAsync(selectedTables, reservationStart, reservationEnd);
            if (!isAvailable)
            {
                throw new InvalidOperationException("One or more tables are not available for the selected time.");
            }

            // Create a time slot for each selected table
            var newTimeSlotsIds = new List<int>();

            foreach (var table in selectedTables)
            {
                var timeSlotCreateDto = new TimeSlotCreateDto
                {
                    StartTime = reservationStart,
                    EndTime = reservationEnd,
                    TableId = table.TableId,
                };

                var createdTimeSlot = await _timeSlotService.CreateTimeSlotAsync(timeSlotCreateDto);
                newTimeSlotsIds.Add(createdTimeSlot.TimeSlotId);
            }

            // Fetch all time slots based on the IDs
            var newTimeSlots = await _timeSlotRepository.GetTimeSlotsByIds(newTimeSlotsIds);

            var reservation = new Reservation
            {
                CustomerId = reservationCreateDto.CustomerId,
                ReservationDate = reservationCreateDto.ReservationDate,
                NumberOfGuests = reservationCreateDto.NumberOfGuests,
                SpecialRequests = reservationCreateDto.SpecialRequests,
                Status = ReservationStatus.Confirmed,
                Tables = selectedTables,
                TimeSlots = newTimeSlots.ToList() // Add the fetched time slots to the reservation
            };

            await _reservationRepository.AddReservation(reservation);

            return _mapper.Map<ReservationDetailsDto>(reservation);
        }



        public async Task<bool> AreTablesAvailableAsync(List<Table> tables, DateTime reservationStart, DateTime reservationEnd)
        {
            // Check if any table is already reserved for the given TimeSlotId
            return !await _reservationRepository.AreTablesReservedAsync(tables.Select(t => t.TableId).ToList(), reservationStart, reservationEnd);
        }


        private async Task ValidateReservationTimeAsync(DateTime reservationDate)
        {
            var dayOfWeek = reservationDate.DayOfWeek;
            var openingHours = await _openingHoursRepository.GetOpeningHoursByDateAsync(reservationDate);
            if (openingHours == null || openingHours.IsClosed)
            {
                throw new InvalidOperationException("The restaurant is closed on the selected date.");
            }

            var specialOpeningHours = openingHours.SpecialOpeningHours
                .FirstOrDefault(soh => soh.Date == DateOnly.FromDateTime(reservationDate));

            TimeOnly openTime, closeTime;

            if (specialOpeningHours != null)
            {
                if (specialOpeningHours.IsClosed)
                {
                    throw new InvalidOperationException("The restaurant is closed on the selected date due to special hours.");
                }
                openTime = specialOpeningHours.OpenTime ?? openingHours.OpenTime;
                closeTime = specialOpeningHours.CloseTime ?? openingHours.CloseTime;
            }
            else
            {
                openTime = openingHours.OpenTime;
                closeTime = openingHours.CloseTime;
            }

            var reservationStart = TimeOnly.FromDateTime(reservationDate);
            var reservationEnd = reservationStart.AddMinutes(90); // Assuming 90 minutes duration

            // Validate if the reservation is within opening hours
            if (reservationStart < openTime || reservationEnd > closeTime)
            {
                throw new InvalidOperationException("The reservation time is outside the restaurant's opening hours.");
            }
        }


        public async Task<ReservationDetailsDto> UpdateReservationAsync(ReservationUpdateDto reservationUpdateDto)
        {
            var existingReservation = await _reservationRepository.GetReservationById(reservationUpdateDto.ReservationId);
            if (existingReservation == null)
            {
                throw new KeyNotFoundException("Reservation does not exist.");
            }

            if (!await _customerRepository.CustomerExistsAsync(reservationUpdateDto.CustomerId))
            {
                throw new KeyNotFoundException($"Customer with ID {reservationUpdateDto.CustomerId} does not exist.");
            }

            await ValidateReservationTimeAsync(reservationUpdateDto.ReservationDate);

            // Fetch the selected tables
            var selectedTableNumbers = reservationUpdateDto.TableNumbers;
            var selectedTables = await _tableRepository.GetTablesByNumbersAsync(selectedTableNumbers);
            if (selectedTables.Count != selectedTableNumbers.Count)
            {
                throw new ArgumentException("One or more table numbers are invalid.");
            }

            int selectedTablesSeatingCapacity = selectedTables.Sum(t => t.SeatingCapacity);
            if (selectedTablesSeatingCapacity < reservationUpdateDto.NumberOfGuests)
            {
                throw new InvalidOperationException($"The selected tables cannot accommodate {reservationUpdateDto.NumberOfGuests} guests. The total seating capacity is {selectedTablesSeatingCapacity}.");
            }

            // Truncate the reservation date to minutes
            var reservationStart = Truncate.TruncateToMinutes(reservationUpdateDto.ReservationDate);
            var reservationEnd = reservationStart.AddMinutes(90);

            // Check if the selected tables are available
            var isAvailable = await AreTablesAvailableAsync(selectedTables, reservationStart, reservationEnd);
            if (!isAvailable)
            {
                throw new InvalidOperationException("One or more tables are not available for the selected time.");
            }

            // Clear existing timeslots and delete them from the database
            if (existingReservation.TimeSlots.Any())
            {
                foreach (var timeslot in existingReservation.TimeSlots.ToList())
                {
                    await _timeSlotRepository.DeleteTimeSlot(timeslot);
                }
                existingReservation.TimeSlots.Clear();
            }

            // Create a time slot for each selected table
            var newTimeSlotsIds = new List<int>();

            foreach (var table in selectedTables)
            {
                var timeSlotCreateDto = new TimeSlotCreateDto
                {
                    StartTime = reservationStart,
                    EndTime = reservationEnd,
                    TableId = table.TableId
                };

                var createdTimeSlot = await _timeSlotService.CreateTimeSlotAsync(timeSlotCreateDto);
                newTimeSlotsIds.Add(createdTimeSlot.TimeSlotId);
            }

            // Fetch all time slots based on the IDs
            var newTimeSlots = await _timeSlotRepository.GetTimeSlotsByIds(newTimeSlotsIds);

            existingReservation.TimeSlots = newTimeSlots.ToList();
            existingReservation.CustomerId = reservationUpdateDto.CustomerId;
            existingReservation.ReservationDate = reservationUpdateDto.ReservationDate;
            existingReservation.NumberOfGuests = reservationUpdateDto.NumberOfGuests;
            existingReservation.SpecialRequests = reservationUpdateDto.SpecialRequests;

            if (existingReservation.Tables == null)
            {
                throw new InvalidOperationException("The Tables property is null.");
            }
            else
            {
                existingReservation.Tables.Clear(); // Remove existing tables from the reservation
                foreach (var table in selectedTables)
                {
                    existingReservation.Tables.Add(table);
                }
            }

            await _reservationRepository.UpdateReservation(existingReservation);           

            return _mapper.Map<ReservationDetailsDto>(existingReservation);
        }



        public async Task DeleteReservationAsync(int id)
        {
            var reservationToDelete = await _reservationRepository.GetReservationById(id);
            if (reservationToDelete == null)
            {
                throw new KeyNotFoundException($"Reservation with ID {id} not found.");
            }

            await _reservationRepository.DeleteReservation(reservationToDelete);
        }
    }
}