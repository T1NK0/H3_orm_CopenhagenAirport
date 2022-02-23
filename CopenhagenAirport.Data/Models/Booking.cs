using System;
using System.Collections.Generic;

namespace CopenhagenAirport.Data.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public DateTime Time { get; set; }
        public string FlightNumber { get; set; } = null!;
        public bool State { get; set; }
        public int AirportId { get; set; }
        public int AirlineId { get; set; }
        public int GateId { get; set; }

        public virtual Airline Airline { get; set; } = null!;
        public virtual Airport Airport { get; set; } = null!;
        public virtual Gate Gate { get; set; } = null!;
    }
}
