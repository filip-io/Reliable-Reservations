namespace Reliable_Reservations.Models.DTOs
{    public class TableDto : TableCreateDto
    {
        public int TableId { get; set; }
    }
    public class TableCreateDto
    {
        public int TableNumber { get; set; }
        public int SeatingCapacity { get; set; }
        public required string Location { get; set; }
    }
}
