using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int TimeSlotId { get; set; }

        [Required]
        [Range(1, 15, ErrorMessage = "Number of guests must be between 1 and 15.")]
        public int NumberOfGuests { get; set; }

        [MaxLength(500)]
        public string SpecialRequests { get; set; }

        [Required]
        public ReservationStatus Status { get; set; }

        public Customer Customer { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public ICollection<Table> Tables { get; set; }
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