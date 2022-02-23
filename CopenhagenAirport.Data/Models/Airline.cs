using System;
using System.Collections.Generic;

namespace CopenhagenAirport.Data.Models
{
    public partial class Airline
    {
        public Airline()
        {
            Bookings = new HashSet<Booking>();
        }

        public int AirlineId { get; set; }
        public string AirlineName { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
