namespace Reliable_Reservations.Models
{
    public class OpeningHours
    {
        public int OpeningHoursId { get; set; }

        public required DayOfWeek DayOfWeek { get; set; }

        public required TimeOnly OpenTime { get; set; } // Using TimeOnly for simplicity and optimization

        public required TimeOnly CloseTime { get; set; } // Using TimeOnly for simplicity and optimization

        public required bool IsClosed { get; set; }

        public virtual ICollection<SpecialOpeningHours> SpecialOpeningHours { get; set; } = new List<SpecialOpeningHours>(); // Initialize to avoid null reference


        // Relationship with TimeSlots
        public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
    }

    public class SpecialOpeningHours
    {
        public int SpecialOpeningHoursId { get; set; }

        public required DateOnly Date { get; set; } // Using DateOnly for simplicity and optimization

        public TimeOnly? OpenTime { get; set; } // Optional: specific open time for that date

        public TimeOnly? CloseTime { get; set; } // Optional: specific close time for that date

        public required bool IsClosed { get; set; }

        public required int OpeningHoursId { get; set; } // Foreign key to OpeningHours

        public OpeningHours? OpeningHours { get; set; } // Navigation property to OpeningHours
    }
}