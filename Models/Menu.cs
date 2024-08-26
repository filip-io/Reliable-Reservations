using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models
{
    public class Menu
    {
        [Key]
        public int MenuItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Required]
        public bool AvailabilityStatus { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
