namespace Reliable_Reservations.Models
{
    public class TimeSlot
    {
        public int TimeSlotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SlotDuration { get; set; } = 120;


        // Relationship with OpeningHours
        public int OpeningHoursId { get; set; } // Foreign Key to OpeningHours
        public virtual OpeningHours? OpeningHours { get; set; }


        // Relationship with Reservations
        public virtual ICollection<Reservation> Reservations { get; set; }


        // Relationship with Tables
        public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
    }
}