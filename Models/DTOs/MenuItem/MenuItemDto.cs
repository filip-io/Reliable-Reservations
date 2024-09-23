using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Reliable_Reservations.Models.DTOs.MenuItem
{
    public class MenuItemDto
    {
        [Required]
        public int MenuItemId { get; set; }

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
        public bool IsPopular { get; set; }

        [JsonIgnore]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
