namespace Reliable_Reservations.Models
{
    public class TimeSlot
    {
        public int TimeSlotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SlotDuration { get; set; } = 120;
        public int OpeningHoursId { get; set; }
        public virtual OpeningHours OpeningHours { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}