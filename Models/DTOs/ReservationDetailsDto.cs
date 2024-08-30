using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs
{
    public class ReservationDetailsDto
    {
        public int ReservationId { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } // Full name of the customer

        [Required]
        public int TimeSlotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public int PartySize { get; set; }

        public string? SpecialRequests { get; set; }

        [Required]
        public ReservationStatus Status { get; set; }

        public List<TableDto> Tables { get; set; } = new List<TableDto>(); // List of detailed tables for the reservation
    }
}
