using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Reliable_Reservations.Models.DTOs
{    public class TableDto
    {
        [Required]
        public required int TableId { get; set; }

        [Required]
        public required int TableNumber { get; set; }

        [Required]
        public required int SeatingCapacity { get; set; }

        [Required]
        public required string Location { get; set; }
    }
}