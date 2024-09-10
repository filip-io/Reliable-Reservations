using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs.MenuItem
{
    public class MenuItemCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public bool AvailabilityStatus { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
