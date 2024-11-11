using Reliable_Reservations.Models.DTOs.Table;
using System.ComponentModel.DataAnnotations;

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
        [Range(1, 8, ErrorMessage = "Number of guests must be between 1 and 8.")]
        public int NumberOfGuests { get; set; }

        public string? SpecialRequests { get; set; }

        public List<TableDto> Tables { get; set; } = new List<TableDto>();
    }
}