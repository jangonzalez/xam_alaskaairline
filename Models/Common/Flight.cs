using System;
namespace Models.Common
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string OriginCode { get; set; }
        public string DestinationCode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
