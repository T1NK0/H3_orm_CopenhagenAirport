// See https://aka.ms/new-console-template for more information
using CopenhagenAirport.Data.Models;

CopenhagenAirportContext context = new CopenhagenAirportContext();


var bookings = context.Bookings.ToList();

Console.WriteLine("Hello, World!");
