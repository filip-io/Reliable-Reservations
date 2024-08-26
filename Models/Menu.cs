namespace Reliable_Reservations.Models
{
    public class Menu
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool AvailabilityStatus { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}