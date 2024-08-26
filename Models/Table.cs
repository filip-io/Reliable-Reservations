namespace Reliable_Reservations.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public int SeatingCapacity { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}