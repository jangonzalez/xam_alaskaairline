using System;
using System.Collections.Generic;
using System.Linq;
using Models.API;
using Flight = Models.Common.Flight;
namespace Models.Converters
{
    public static class FlightConverters
    {
        public static IList<Flight> ToFlights(this FlightResponse response)
        {
            var flights = new List<Flight>();

            if (response != null && response.Flights != null)
            {
                foreach (var flight in response.Flights)
                {
                    if (flight.FlightDetails != null)
                    {
                        var leg = flight.FlightDetails.FlightLegs.First();

                        flights.Add(new Flight()
                        {
                            FlightNumber = flight.FlightDetails.OperatingFlightNumber,
                            OriginCode = leg.ActualDepartureStation.AirportCode,
                            DestinationCode = leg.ActualArrivalStation.AirportCode,
                            DepartureTime = leg.EstimatedDateTimeUTC.Out,
                            ArrivalTime = leg.EstimatedDateTimeUTC.In
                        });
                    }
                }
            }

            return flights;
        }
    }
}
