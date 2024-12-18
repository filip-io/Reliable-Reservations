﻿using Reliable_Reservations.Models.DTOs.Customer;
using Reliable_Reservations.Models.DTOs.Table;
using Reliable_Reservations.Models.DTOs.TimeSlot;

namespace Reliable_Reservations.Models.DTOs.Reservation
{
    public class ReservationDetailsDto
    {
        public int ReservationId { get; set; }

        public CustomerDto? Customer { get; set; }

        public DateTime ReservationDate { get; set; }

        public int NumberOfGuests { get; set; }

        public string? SpecialRequests { get; set; }

        public ReservationStatus Status { get; set; }

        public List<TableDto> Tables { get; set; } = new List<TableDto>(); // List of detailed tables for the reservation

        public List<TimeSlotDto> TimeSlots { get; set; } = new List<TimeSlotDto>();
    }
}
