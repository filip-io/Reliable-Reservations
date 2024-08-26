using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }

        [Required]
        [Range(1, 25, ErrorMessage = "Table number must be between 1 and 25.")]
        public int TableNumber { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Seating capacity must be between 1 and 10.")]
        public int SeatingCapacity { get; set; }

        [MaxLength(50)]
        public string Location { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}