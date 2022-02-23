using System;
using System.Collections.Generic;

namespace CopenhagenAirport.Data.Models
{
    public partial class Airport
    {
        public Airport()
        {
            Bookings = new HashSet<Booking>();
        }

        public int AirportId { get; set; }
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string AirportName { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
