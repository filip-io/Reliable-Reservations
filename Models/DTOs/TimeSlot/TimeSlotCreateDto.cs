using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs.TimeSlot
{
    public class TimeSlotCreateDto
    {
        [Required]
        public required DateTime StartTime { get; set; }

        [Required]
        public required DateTime EndTime { get; set; }
    }
}
