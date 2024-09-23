using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs.TimeSlot
{
    public class TimeSlotDto
    {
        [Required]
        public int TimeSlotId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int TableId { get; set; }

        [Required]
        public int? ReservationId { get; set; }
    }
}