// See https://aka.ms/new-console-template for more information
using CopenhagenAirport.Data.Models;

CopenhagenAirportContext context = new CopenhagenAirportContext();


var bookings = context.Bookings.ToList();
var airlines = context.Airlines.ToList();
var airports = context.Airports.ToList();
var gates = context.Gates.ToList();

Booking bookingCreate = new Booking();
bookingCreate.Time = new DateTime(2022, 02, 23, 08, 15, 00);
bookingCreate.Airline = new Airline() { AirlineName = "ALSIE EXPRESS A/S" };
bookingCreate.Airport = new Airport() { AirportName = "Sonderborg Airport", City = "Sonderborg", Country = "Denmark" };
bookingCreate.FlightNumber = "6I102";
bookingCreate.Gate = new Gate() { GateName = "A9"};
//Trying to get a check on if it exists and then update it instead.

//foreach (var booking in bookings)
//{
//    if (booking.BookingId == bookingCreate.BookingId)
//    {
//        context.Bookings.Update(bookingCreate);
//    }
//    else
//    {
//        context.Bookings.Add(bookingCreate);
//    }
//}

//    if (bookings.Contains(bookingCreate))
//{
//    context.Bookings.Update(bookingCreate);
//}
//else
//{
//    context.Bookings.Add(bookingCreate);
//}

context.Bookings.Add(bookingCreate);
context.SaveChanges();


//Prints our bookings.
foreach (var booking in bookings)
{
    //Console.WriteLine("Booking id: " + booking.BookingId);
    Console.WriteLine("Booking number: " + booking.FlightNumber);
    Console.WriteLine("Airline name: " + booking.Airline.AirlineName);
    if (booking.State == true)
    {
        Console.WriteLine("Departure time: " + booking.Time);
        Console.WriteLine("Going to: " + booking.Airport.AirportName + ", " + booking.Airport.City + ", " + booking.Airport.Country);
        Console.WriteLine("Flying from gate: " + booking.Gate.GateName);
    }
    else
    {
        Console.WriteLine("Arrival time: " + booking.Time);
        Console.WriteLine("Comming from: " + booking.Airport.AirportName + ", " + booking.Airport.City + ", " + booking.Airport.Country);
        Console.WriteLine("Going to gate: " + booking.Gate.GateName);
    }

    Console.WriteLine("");
}


Console.WriteLine("Hello, World!");
