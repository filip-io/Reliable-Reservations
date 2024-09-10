using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs.OpeningHours
{
    public class OpeningHoursDto
    {
        [Required]
        public int OpeningHoursId { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public TimeOnly OpenTime { get; set; } // Using TimeOnly for simplicity and optimization

        [Required]
        public TimeOnly CloseTime { get; set; } // Using TimeOnly for simplicity and optimization

        [Required]
        public bool IsClosed { get; set; }

        public virtual ICollection<SpecialOpeningHoursDto> SpecialOpeningHours { get; set; } = new List<SpecialOpeningHoursDto>(); // Initialize to avoid null reference

        // public virtual ICollection<TimeSlotDto> TimeSlots { get; set; }
    }

    public class SpecialOpeningHoursDto
    {
        public int SpecialOpeningHoursId { get; set; }

        [Required]
        public DateOnly Date { get; set; } // Using DateOnly for simplicity and optimization

        public TimeOnly? OpenTime { get; set; } // Optional: specific open time for that date

        public TimeOnly? CloseTime { get; set; } // Optional: specific close time for that date

        [Required]
        public bool IsClosed { get; set; }

        [Required]
        public int OpeningHoursId { get; set; } // Foreign key to OpeningHours
    }
}