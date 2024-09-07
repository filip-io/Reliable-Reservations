using Reliable_Reservations.Models;
public class Table
{
    public int TableId { get; set; }
    public int TableNumber { get; set; }
    public int SeatingCapacity { get; set; }
    public string Location { get; set; } = string.Empty;

    // Relationshop with Reservations
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    // Relationship with TimeSlots
    public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
}