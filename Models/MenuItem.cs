using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models
{
    public enum Category
    {
        Appetizer,
        Starter,
        MainCourse,
        Dessert,
        Beverage,
        SideDish,
        Soup,
        Salad,
        Special,
        Kids,
        Vegetarian
    }

    public class MenuItem
    {
        [Required]
        public required int MenuItemId { get; set; }
        
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required decimal Price { get; set; }

        [Required]
        public required Category Category { get; set; }

        [Required]
        public required bool AvailabilityStatus { get; set; }

        [Required]
        public required DateTime LastUpdated { get; set; }
    }
}