using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs
{
    public class TimeSlotDto
    {
        [Required]
        public required int TimeSlotId { get; set; }

        [Required]
        public required TimeSpan StartTime { get; set; }

        [Required]
        public required TimeSpan EndTime { get; set; }

        [Required]
        public required TimeSpan SlotDuration { get; set; }

        [Required]
        public required int OpeningHoursId { get; set; }
    }
}
