﻿using System.ComponentModel.DataAnnotations;

namespace Reliable_Reservations.Models.DTOs
{
    public class TimeSlotAutoGenerateDto
    {
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Slot duration is required.")]
        [Range(60, 120, ErrorMessage = "Slot duration must be between 60 and 120 minutes.")]
        public int SlotDuration { get; set; }
    }
}