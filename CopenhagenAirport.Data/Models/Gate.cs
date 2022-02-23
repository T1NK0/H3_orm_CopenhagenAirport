using System;
using System.Collections.Generic;

namespace CopenhagenAirport.Data.Models
{
    public partial class Gate
    {
        public Gate()
        {
            Bookings = new HashSet<Booking>();
        }

        public int GateId { get; set; }
        public string GateName { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
