using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Models;
public class Table
{
    public int TableId { get; set; }
    public int TableNumber { get; set; }
    public int SeatingCapacity { get; set; }
    public string Location { get; set; } = string.Empty;
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>(); // Initialize to avoid nullref
}