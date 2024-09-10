using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs.Table
{
    public class TableDto
    {
        [Required]
        public int TableId { get; set; }

        [Required]
        public int TableNumber { get; set; }

        [Required]
        public int SeatingCapacity { get; set; }

        [Required]
        public string Location { get; set; }
    }
}