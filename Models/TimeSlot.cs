using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models
{
    public class TimeSlot
    {
        public int TimeSlotId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }


        // Relationship with OpeningHours (each time slot is linked to the opening hours that generated it)
        [Required]
        public int OpeningHoursId { get; set; } // Foreign key to OpeningHours
        public virtual OpeningHours OpeningHours { get; set; } // Navigation property


        // Relationship with Table (each time slot is assigned to a specific table)
        [Required]
        public int TableId { get; set; }
        public virtual Table Table { get; set; }


        // Relationship with Reservation (a time slot may have one reservation)
        public int? ReservationId { get; set; }
        public virtual Reservation? Reservation { get; set; }
    }
}