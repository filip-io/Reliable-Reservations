using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs
{
    public class TimeSlotDto
    {
        [Required]
        public required int TimeSlotId { get; set; }

        [Required]
        public required DateTime StartTime { get; set; }

        [Required]
        public required DateTime EndTime { get; set; }

        [Required]
        public required int SlotDuration { get; set; }
    }
}