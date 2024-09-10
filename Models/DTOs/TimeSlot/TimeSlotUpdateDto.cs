namespace Reliable_Reservations.Models.DTOs.TimeSlot
{
    public class TimeSlotUpdateDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SlotDuration { get; set; } = 120;
    }
}
