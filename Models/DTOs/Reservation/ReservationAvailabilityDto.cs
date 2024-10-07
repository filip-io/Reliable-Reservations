namespace Reliable_Reservations.Models.DTOs.Reservation
{
    public class ReservationExistDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<int> TableNumbers { get; set; }
    }
}
