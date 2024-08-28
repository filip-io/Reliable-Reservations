namespace Reliable_Reservations.Models.DTOs
{
    public class CustomerDto : CustomerCreateDto
    {
        public int CustomerId { get; set; }
    }
    public class CustomerCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}