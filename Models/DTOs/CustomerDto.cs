using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Reliable_Reservations.Models.DTOs
{
    public class CustomerDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [JsonIgnore]
        public string FullName => $"{FirstName} {LastName}"; // Not stored (read-only), just for convenience

        [Required]
        [Phone(ErrorMessage = "Not a valid phone number.")]
        public required string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public required string Email { get; set; }
    }
}