namespace Reliable_Reservations.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public required int TableNumber { get; set; }
        public required int SeatingCapacity { get; set; }
        public string Location { get; set; } = string.Empty;


        // Relationship with TimeSlots (each table has specific available times)
        public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();


        // Relationship with Reservations (tables can be reserved in time slots)
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}