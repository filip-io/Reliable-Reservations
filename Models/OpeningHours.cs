﻿using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models
{
    public class OpeningHours
    {
        public int OpeningHoursId { get; set; }

        [Required]
        public required DayOfWeek DayOfWeek { get; set; }

        [Required]
        public required TimeOnly OpenTime { get; set; } // Using TimeOnly for simplicity and optimization

        [Required]
        public required TimeOnly CloseTime { get; set; } // Using TimeOnly for simplicity and optimization

        [Required]
        public required bool IsClosed { get; set; } // Whether the restaurant is closed that day

        public virtual ICollection<SpecialOpeningHours> SpecialOpeningHours { get; set; } = new List<SpecialOpeningHours>(); // Initialize to avoid null reference

        
        // Relationship with TimeSlots
        public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
    }

    public class SpecialOpeningHours
    {
        public int SpecialOpeningHoursId { get; set; }

        [Required]
        public required DateOnly Date { get; set; } // Using DateOnly for simplicity and optimization

        public TimeOnly? OpenTime { get; set; } // Optional: specific open time for that date

        public TimeOnly? CloseTime { get; set; } // Optional: specific close time for that date

        [Required]
        public bool IsClosed { get; set; } // Whether the restaurant is closed on that special date

        [Required]
        public required int OpeningHoursId { get; set; } // Foreign key to OpeningHours

        public OpeningHours? OpeningHours { get; set; } // Navigation property to OpeningHours
    }
}