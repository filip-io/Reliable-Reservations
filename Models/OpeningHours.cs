using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models
{
    public class OpeningHours
    {
        [Key]
        public int OpeningHoursId { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public TimeSpan OpenTime { get; set; }

        [Required]
        public TimeSpan CloseTime { get; set; }

        [Required]
        public bool IsClosed { get; set; }

        public TimeSpan? SpecialOpenTime { get; set; }
        public TimeSpan? SpecialCloseTime { get; set; }
        public DateTime? SpecialDate { get; set; }

        public ICollection<TimeSlot> TimeSlots { get; set; }
    }
}