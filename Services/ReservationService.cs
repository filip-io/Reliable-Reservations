using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Repos.IRepos;
using Reliable_Reservations.Repositories.IRepos;
using Reliable_Reservations.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reliable_Reservations.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationDto>> GetAllReservationsAsync()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }

        public async Task<ReservationDto?> GetReservationByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            return _mapper.Map<ReservationDto>(reservation);
        }

        public async Task<ReservationDto> CreateReservationAsync(ReservationCreateDto reservationCreateDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationCreateDto);
            await _reservationRepository.AddAsync(reservation);
            return _mapper.Map<ReservationDto>(reservation);
        }

        public async Task<ReservationDto> UpdateReservationAsync(ReservationDto reservationDto)
        {
            var existingReservation = await _reservationRepository.GetByIdAsync(reservationDto.ReservationId);
            if (existingReservation == null)
            {
                throw new KeyNotFoundException($"Reservation with ID {reservationDto.ReservationId} not found.");
            }

            _mapper.Map(reservationDto, existingReservation);
            await _reservationRepository.UpdateAsync(existingReservation);
            return _mapper.Map<ReservationDto>(existingReservation);
        }

        public async Task DeleteReservationAsync(int id)
        {
            await _reservationRepository.DeleteAsync(id);
        }
    }
}