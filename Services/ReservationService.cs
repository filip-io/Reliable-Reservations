using AutoMapper;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.ViewModels;
using Reliable_Reservations.Services.IServices;
using Reliable_Reservations.Helpers;
using Reliable_Reservations.Models.DTOs.Reservation;

namespace Reliable_Reservations.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableService _tableService;
        private readonly ITableRepository _tableRepository;
        private readonly ITimeSlotService _timeSlotService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOpeningHoursRepository _openingHoursRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ReservationService> _logger;

        public ReservationService(
            IReservationRepository reservationRepository,
            ITableService tableService,
            ITableRepository tableRepository,
            ITimeSlotService timeSlotService,
            ICustomerRepository customerRepository,
            IOpeningHoursRepository openingHoursRepository,
            IMapper mapper,
            ILogger<ReservationService> logger)
        {
            _reservationRepository = reservationRepository;
            _tableService = tableService;
            _tableRepository = tableRepository;
            _timeSlotService = timeSlotService;
            _customerRepository = customerRepository;
            _openingHoursRepository = openingHoursRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ReservationDetailsViewModel>> GetAllReservationsAsync()
        {
            var reservations = await _reservationRepository.GetAllReservations();
            return _mapper.Map<IEnumerable<ReservationDetailsViewModel>>(reservations);
        }

        public async Task<ReservationDetailsViewModel?> GetReservationByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetReservationById(id);

            if (reservation == null)
            {
                throw new KeyNotFoundException($"Reservation with ID {id} not found.");
            }

            return _mapper.Map<ReservationDetailsViewModel?>(reservation);
        }

        public async Task<ReservationDetailsViewModel> CreateReservationAsync(ReservationCreateDto reservationCreateDto)
        {
            if (reservationCreateDto.ReservationDate < DateTime.Now)
            {
                throw new ArgumentException("Reservations cannot be made for past dates and times.");
            }

            if (!await _customerRepository.CustomerExists(reservationCreateDto.CustomerId))
            {
                throw new ArgumentException("Customer does not exist.");
            }

            await ValidateReservationTimeAsync(reservationCreateDto.ReservationDate);

            // Fetch the selected tables
            var selectedTables = await _tableRepository.GetTablesByNumbersAsync(reservationCreateDto.TableNumbers);
            if (selectedTables.Count != reservationCreateDto.TableNumbers.Count)
            {
                throw new ArgumentException("One or more table numbers are invalid.");
            }

            int totalSeatingCapacity = selectedTables.Sum(table => table.SeatingCapacity);
            if (totalSeatingCapacity < reservationCreateDto.NumberOfGuests)
            {
                throw new InvalidOperationException($"The selected tables cannot accommodate {reservationCreateDto.NumberOfGuests} guests. The total seating capacity is {totalSeatingCapacity}.");
            }

            // Retrieve all time slots associated with the selected tables
            var timeSlots = await _timeSlotService.GetTimeSlotsByTablesAsync(selectedTables.Select(t => t.TableId).ToList());


            // Remove any fractions of time from the booking
            var reservationDate = Truncate.TruncateToMinutes(reservationCreateDto.ReservationDate);

            var matchingTimeSlot = timeSlots
                .FirstOrDefault(ts => ts.StartTime <= reservationDate && ts.EndTime >= reservationDate.AddMinutes(90));


            if (matchingTimeSlot == null)
            {
                throw new InvalidOperationException("No matching time slot found for the selected time.");
            }

            // Check if the selected tables are available for the time slot
            var isAvailable = await AreTablesAvailableAsync(selectedTables, matchingTimeSlot.TimeSlotId);
            if (!isAvailable)
            {
                throw new InvalidOperationException("One or more tables are not available for the selected time slot.");
            }

            var reservation = new Reservation
            {
                CustomerId = reservationCreateDto.CustomerId,
                TimeSlotId = matchingTimeSlot.TimeSlotId,
                ReservationDate = reservationCreateDto.ReservationDate,
                NumberOfGuests = reservationCreateDto.NumberOfGuests,
                SpecialRequests = reservationCreateDto.SpecialRequests,
                Status = ReservationStatus.Pending,
                Tables = selectedTables
            };

            await _reservationRepository.AddReservation(reservation);

            return _mapper.Map<ReservationDetailsViewModel>(reservation);
        }


        public async Task<bool> AreTablesAvailableAsync(List<Table> tables, int timeSlotId)
        {
            // Check if any table is already reserved for the given TimeSlotId
            return !await _reservationRepository.AreTablesReservedAsync(tables.Select(t => t.TableId).ToList(), timeSlotId);
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


        public async Task<ReservationDetailsViewModel> UpdateReservationAsync(ReservationUpdateDto reservationUpdateDto)
        {
            var existingReservation = await _reservationRepository.GetReservationById(reservationUpdateDto.ReservationId);
            if (existingReservation == null)
            {
                throw new KeyNotFoundException("Reservation does not exist.");
            }

            if (!await _customerRepository.CustomerExists(reservationUpdateDto.CustomerId))
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

            // Retrieve all time slots associated with the selected tables
            var timeSlots = await _timeSlotService.GetTimeSlotsByTablesAsync(selectedTables.Select(t => t.TableId).ToList());

            var newTimeSlot = timeSlots
                .FirstOrDefault(ts => ts.StartTime <= reservationUpdateDto.ReservationDate && ts.EndTime >= reservationUpdateDto.ReservationDate.AddMinutes(90)); // Assuming 90 minutes duration

            if (newTimeSlot == null)
            {
                throw new InvalidOperationException("No matching time slot found for the selected time.");
            }

            // Check if the selected tables are available for the new TimeSlotId
            var isAvailable = await AreTablesAvailableAsync(selectedTables, newTimeSlot.TimeSlotId);
            if (!isAvailable)
            {
                throw new InvalidOperationException("One or more tables are not available for the selected time slot.");
            }

            existingReservation.TimeSlotId = newTimeSlot.TimeSlotId;
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

            return _mapper.Map<ReservationDetailsViewModel>(existingReservation);
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