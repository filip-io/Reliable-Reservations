using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs
{
    public class TableCreateDto
    {
        [Required]
        public required int TableNumber { get; set; }

        [Required]
        public required int SeatingCapacity { get; set; }

        [Required]
        public required string Location { get; set; }
    }
}
