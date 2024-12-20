using System.Collections.Generic;
using System.Linq;

namespace SmartAirport.Services
{
    public class FlightService
    {
        private List<Flight> flights = new List<Flight>
        {
            new Flight { FlightNumber = "SU123", Destination = "Москва", DepartureTime = "10:00", Status = "Вовремя" },
            new Flight { FlightNumber = "BA456", Destination = "Лондон", DepartureTime = "12:30", Status = "Задержан" },
            new Flight { FlightNumber = "LH789", Destination = "Берлин", DepartureTime = "14:15", Status = "Отменен" }
        };

        public List<Flight> GetAllFlights()
        {
            return flights;
        }

        public void AddFlight(Flight flight)
        {
            flights.Add(flight);
        }

        public void RemoveFlight(string flightNumber)
        {
            var flight = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
            if (flight != null) flights.Remove(flight);
        }

        public void UpdateFlight(Flight updatedFlight)
        {
            var flight = flights.FirstOrDefault(f => f.FlightNumber == updatedFlight.FlightNumber);
            if (flight != null)
            {
                flight.Destination = updatedFlight.Destination;
                flight.DepartureTime = updatedFlight.DepartureTime;
                flight.Status = updatedFlight.Status;
            }
        }
    }
}