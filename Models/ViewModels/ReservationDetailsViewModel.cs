using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Reliable_Reservations.Models.DTOs;

namespace Reliable_Reservations.Models.ViewModels
{
    public class ReservationDetailsViewModel
    {
        public int ReservationId { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }  // Full name of the customer

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime ReservationDate { get; set; }

        public int NumberOfGuests { get; set; }

        public string? SpecialRequests { get; set; }

        public ReservationStatus Status { get; set; }

        public List<TableDto> Tables { get; set; } = new List<TableDto>(); // List of detailed tables for the reservation
    }
}
