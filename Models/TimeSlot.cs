using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models
{
    public class TimeSlot
    {
        [Key]
        public int TimeSlotId { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public TimeSpan SlotDuration { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}