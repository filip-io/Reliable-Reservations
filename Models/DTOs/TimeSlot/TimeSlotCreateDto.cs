using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs.TimeSlot
{
    public class TimeSlotCreateDto
    {
        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
    }
}
