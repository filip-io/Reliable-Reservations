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

        public required DateTime ReservationDate { get; set; }

        public required int NumberOfGuests { get; set; }

        public string? SpecialRequests { get; set; } = null;

        public required ReservationStatus Status { get; set; } = ReservationStatus.Confirmed;


        // Relationship with Customer
        public int CustomerId { get; set; } // Foreign Key to Customer
        public virtual Customer? Customer { get; set; } // Navigation property to Customer


        // Relationship with Tables to have access to reserved tables
        public virtual ICollection<Table> Tables { get; set; } = new List<Table>(); // Initialize to avoid null reference


        // Relationship with TimeSlot
        public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>(); // Initialize to avoid null reference
    }
}