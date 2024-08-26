namespace Reliable_Reservations.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int TimeSlotId { get; set; }
        public int NumberOfGuests { get; set; }
        public string SpecialRequests { get; set; }
        public ReservationStatus Status { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Canceled,
        Completed,
        NoShow
    }
}