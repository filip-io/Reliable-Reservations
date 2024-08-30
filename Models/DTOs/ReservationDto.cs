using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs
{
    public class ReservationDto
    {
        [Required]
        public int ReservationId { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; } // Including a CustomerDto for customer details

        [Required]
        public int TimeSlotId { get; set; }
        public TimeSlotDto TimeSlot { get; set; } // Including a TimeSlotDto for time slot details

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        [Range(1, 15, ErrorMessage = "Number of guests must be between 1 and 15.")]
        public int NumberOfGuests { get; set; }

        public string? SpecialRequests { get; set; }

        [Required]
        public ReservationStatus Status { get; set; }

        public List<TableDto> Tables { get; set; } = new List<TableDto>(); // Including a list of TableDto for tables
    }
}