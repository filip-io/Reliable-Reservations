using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repos;
using Reliable_Reservations.Repos.IRepos;
using Reliable_Reservations.Repositories;
using Reliable_Reservations.Repositories.IRepos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reliable_Reservations.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly IMapper _mapper;

        public ReservationService
            (
            IReservationRepository reservationRepository,
            ITableRepository tableRepository,
            ITimeSlotRepository timeSlotRepository,
            IMapper mapper
            )
        {
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
            _timeSlotRepository = timeSlotRepository;
            _mapper = mapper;
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
            // Check if the selected tables are valid
            var selectedTables = await _tableRepository.GetTablesByNumbersAsync(reservationCreateDto.TableNumbers);
            
            if (selectedTables.Count != reservationCreateDto.TableNumbers.Count)
            {
                throw new ArgumentException("One or more table numbers are invalid.");
            }

            // Check if selected tables are available at the requested time slot
            var timeSlot = await _timeSlotRepository.GetTimeSlotByDate(reservationCreateDto.ReservationDate);

            if (timeSlot == null)
            {
                throw new InvalidOperationException("No available time slot found for the given reservation date.");
            }

            var existingReservations = await _reservationRepository.GetReservationsForTimeSlotAndTables(timeSlot.TimeSlotId, reservationCreateDto.TableNumbers);

            if (existingReservations.Any())
            {
                throw new InvalidOperationException("One or more selected tables are already booked for the given time slot.");
            }

            // Create the reservation
            var reservation = new Reservation
            {
                CustomerId = reservationCreateDto.CustomerId,
                TimeSlotId = timeSlot.TimeSlotId,
                ReservationDate = reservationCreateDto.ReservationDate,
                NumberOfGuests = reservationCreateDto.NumberOfGuests,
                SpecialRequests = reservationCreateDto.SpecialRequests,
                Status = ReservationStatus.Pending,
                Tables = selectedTables
            };

            await _reservationRepository.AddAsync(reservation);
            await _reservationRepository.SaveChangesAsync();

            return _mapper.Map<ReservationDto>(reservation);
        }

        public async Task<ReservationDto> UpdateReservationAsync(ReservationDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);

            var updatedReservation = await _reservationRepository.UpdateReservation(reservation);

            var updatedReservationDto = _mapper.Map<ReservationDto>(updatedReservation);

            return updatedReservationDto;
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            await _reservationRepository.DeleteReservation(reservationId);
        }
    }
}