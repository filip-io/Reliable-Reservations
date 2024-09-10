using System.ComponentModel.DataAnnotations;
using Reliable_Reservations.Models.DTOs.Table;

namespace Reliable_Reservations.Models.DTOs.Reservation
{
    public class ReservationDto
    {
        [Required]
        public int ReservationId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        [Range(1, 15, ErrorMessage = "Number of guests must be between 1 and 15.")]
        public int NumberOfGuests { get; set; }

        public string? SpecialRequests { get; set; }

        public List<TableDto> Tables { get; set; } = new List<TableDto>(); // Including a list of TableDto for tables
    }
}