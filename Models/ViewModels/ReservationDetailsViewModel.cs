using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Reliable_Reservations.Models.DTOs.Table;

namespace Reliable_Reservations.Models.ViewModels
{
    public class ReservationDetailsViewModel
    {
        public int ReservationId { get; set; }

        public CustomerViewModel Customer { get; set; }

        public DateTime ReservationDate { get; set; }

        public int SlotDuration { get; set; }

        public int NumberOfGuests { get; set; }

        public string? SpecialRequests { get; set; }

        public ReservationStatus Status { get; set; }

        public List<TableDto> Tables { get; set; } = new List<TableDto>(); // List of detailed tables for the reservation
    }
}
