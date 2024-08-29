using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Reliable_Reservations.Models.DTOs
{
    public class OpeningHoursDto
    {
        [Required]
        public int OpeningHoursId { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required DayOfWeek Day { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public required TimeSpan OpenTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public required TimeSpan CloseTime { get; set; }

        [Required]
        public required bool IsClosed { get; set; }
    }
}