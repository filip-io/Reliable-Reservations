namespace Reliable_Reservations.Models
{
    public class TimeSlot
    {
        public int TimeSlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan SlotDuration { get; set; }
        public int OpeningHoursId { get; set; }
        public virtual OpeningHours OpeningHours { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}