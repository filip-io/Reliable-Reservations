using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs
{
    public class ReservationCreateDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int TimeSlotId { get; set; }

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