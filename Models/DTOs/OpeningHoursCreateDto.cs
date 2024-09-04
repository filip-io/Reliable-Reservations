using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs
{
    public class OpeningHoursCreateDto
    {
        [Required]
        public required DayOfWeek DayOfWeek { get; set; }

        [Required]
        public required TimeOnly OpenTime { get; set; } // Using TimeOnly for simplicity and optimization

        [Required]
        public required TimeOnly CloseTime { get; set; } // Using TimeOnly for simplicity and optimization

        [Required]
        public required bool IsClosed { get; set; }

        public virtual ICollection<SpecialOpeningHoursCreateDto> SpecialOpeningHours { get; set; } = new List<SpecialOpeningHoursCreateDto>(); // Initialize to avoid null reference
    }

    public class SpecialOpeningHoursCreateDto
    {
        public DateOnly Date { get; set; } // Using DateOnly for simplicity and optimization

        public TimeOnly? OpenTime { get; set; } // Optional: specific open time for that date

        public TimeOnly? CloseTime { get; set; } // Optional: specific close time for that date

        public bool IsClosed { get; set; } // Whether the restaurant is closed on that special date

        [Required]
        public required int OpeningHoursId { get; set; } // Foreign key to OpeningHours
    }
}
