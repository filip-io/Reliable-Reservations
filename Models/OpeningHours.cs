namespace Reliable_Reservations.Models
{
    public class OpeningHours
    {
        public int OpeningHoursId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public bool IsClosed { get; set; }
        public DateTime? SpecialDate { get; set; }
        public TimeSpan? SpecialOpenTime { get; set; }
        public TimeSpan? SpecialCloseTime { get; set; }
        public virtual ICollection<TimeSlot> TimeSlots { get; set; }
    }
}