using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models
{
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Canceled,
        Completed,
        NoShow
    }

    public class Reservation
    {
        public int ReservationId { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }

        public string? SpecialRequests { get; set; } = null;

        [Required]
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

        public virtual ICollection<Table> Tables { get; set; } = new List<Table>(); // Initialize to avoid null reference


        // Relationship with Customer
        [Required]
        public int CustomerId { get; set; } // Foreign Key to Customer
        public virtual Customer? Customer { get; set; } // Navigation property to Customer


        // Relationship with TimeSlot
        [Required]
        public int TimeSlotId { get; set; } // Foreign Key to TimeSlot
        public virtual TimeSlot? TimeSlot { get; set; } // Navigation property to TimeSlot
    }
}