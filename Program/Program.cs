// See https://aka.ms/new-console-template for more information
using CopenhagenAirport.Data.Models;

Console.WriteLine("Hello, World!");

CopenhagenAirportContext context = new CopenhagenAirportContext();

//Gets our data from the database and puts it into the following lists
var bookings = context.Bookings.ToList();
var gates = context.Gates.ToList();
var airlines = context.Airlines.ToList();
var airports = context.Airports.ToList();

foreach (var booking in bookings)
{
    Console.WriteLine("booking id: " + booking.BookingId);
    Console.WriteLine("booking flightnumber: " + booking.FlightNumber);

    //foreach (var airline in booking.Airlines)
    //{
    //    Console.WriteLine("Alcohol name: " + alcohol.Name);
    //    Console.WriteLine("Alcohol type: " + alcohol.Type);
    //}

    //foreach (var ingredient in drink.Ingredients)
    //{
    //    Console.WriteLine("Ingredient name: " + ingredient.Name);
    //    Console.WriteLine("Ingredient type:" + ingredient.Type);
    //}

    //foreach (var accesory in drink.Accessories)
    //{
    //    Console.WriteLine("Accesory name: " + accesory.Name);
    //    Console.WriteLine("Accesory type: " + accesory.Type);
    //}
    Console.WriteLine();
}