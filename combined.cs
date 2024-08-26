namespace Reliable_Reservations.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
namespace Reliable_Reservations.Models
{
    public class Menu
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool AvailabilityStatus { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
namespace Reliable_Reservations.Models
{
    public class OpeningHours
    {
        public int OpeningHoursId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public bool IsClosed { get; set; }
        public TimeSpan? SpecialOpenTime { get; set; }
        public TimeSpan? SpecialCloseTime { get; set; }
        public DateTime? SpecialDate { get; set; }

        public ICollection<TimeSlot> TimeSlots { get; set; }
    }
}
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
namespace Reliable_Reservations.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public  int SeatingCapacity { get; set; }
        public string Location { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
namespace Reliable_Reservations.Models
{
    public class TimeSlot
    {
        public int TimeSlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan SlotDuration { get; set; }


        public ICollection<Reservation> Reservations { get; set; }
    }
}
