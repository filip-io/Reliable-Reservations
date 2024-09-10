using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs.Customer
{
    public class CustomerDto
    {
        [Required]
        public required int CustomerId { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        [Phone(ErrorMessage = "Not a valid phone number.")]
        public required string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public required string Email { get; set; }
    }
}