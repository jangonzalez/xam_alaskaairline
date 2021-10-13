using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models.API
{
    public class ScheduledDateTimeUTC
    {
        [JsonProperty("out")]
        public DateTime Out { get; set; }

        [JsonProperty("in")]
        public DateTime In { get; set; }
    }

    public class SubDelayInformationList
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("minutes")]
        public string Minutes { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }

    public class DelayInformation
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("minutes")]
        public string Minutes { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("subDelayInformationList")]
        public List<SubDelayInformationList> SubDelayInformationList { get; set; }
    }

    public class EstimatedDateTimeUTC
    {
        [JsonProperty("out")]
        public DateTime Out { get; set; }

        [JsonProperty("in")]
        public DateTime In { get; set; }

        [JsonProperty("delayInformation")]
        public List<DelayInformation> DelayInformation { get; set; }
    }

    public class Gate
    {
        [JsonProperty("podium")]
        public string Podium { get; set; }

        [JsonProperty("parkingSpot")]
        public string ParkingSpot { get; set; }

        [JsonProperty("carousel")]
        public object Carousel { get; set; }
    }

    public class ActualDepartureStation
    {
        [JsonProperty("airportCode")]
        public string AirportCode { get; set; }

        [JsonProperty("zuluOffset")]
        public int ZuluOffset { get; set; }

        [JsonProperty("gate")]
        public Gate Gate { get; set; }

        [JsonProperty("countryCode2Letters")]
        public string CountryCode2Letters { get; set; }

        [JsonProperty("countryCode3Letters")]
        public string CountryCode3Letters { get; set; }
    }

    public class ActualArrivalStation
    {
        [JsonProperty("airportCode")]
        public string AirportCode { get; set; }

        [JsonProperty("zuluOffset")]
        public int ZuluOffset { get; set; }

        [JsonProperty("gate")]
        public Gate Gate { get; set; }

        [JsonProperty("countryCode2Letters")]
        public string CountryCode2Letters { get; set; }

        [JsonProperty("countryCode3Letters")]
        public string CountryCode3Letters { get; set; }
    }

    public class Actualdatetimeutc
    {
        [JsonProperty("out")]
        public DateTime? Out { get; set; }

        [JsonProperty("in")]
        public DateTime? In { get; set; }

        [JsonProperty("on")]
        public DateTime? On { get; set; }

        [JsonProperty("off")]
        public DateTime? Off { get; set; }
    }

    public class ScheduledArrivalStation
    {
        [JsonProperty("airportCode")]
        public string AirportCode { get; set; }
    }

    public class ScheduledDepartureStation
    {
        [JsonProperty("airportCode")]
        public string AirportCode { get; set; }
    }

    public class CodeShare
    {
        [JsonProperty("marketingFlightNumber")]
        public string MarketingFlightNumber { get; set; }

        [JsonProperty("marketingAirlineCode")]
        public string MarketingAirlineCode { get; set; }
    }

    public class Aircraft
    {
        [JsonProperty("aircraftRegistration")]
        public string AircraftRegistration { get; set; }

        [JsonProperty("fleetType")]
        public string FleetType { get; set; }

        [JsonProperty("fleetSeries")]
        public string FleetSeries { get; set; }

        [JsonProperty("iataAircraftCode")]
        public string IataAircraftCode { get; set; }

        [JsonProperty("oagFleetCode")]
        public string OagFleetCode { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }
    }

    public class FlightLeg
    {
        [JsonProperty("legNumber")]
        public int LegNumber { get; set; }

        [JsonProperty("scheduledDateTimeUTC")]
        public ScheduledDateTimeUTC ScheduledDateTimeUTC { get; set; }

        [JsonProperty("estimatedDateTimeUTC")]
        public EstimatedDateTimeUTC EstimatedDateTimeUTC { get; set; }

        [JsonProperty("actualDepartureStation")]
        public ActualDepartureStation ActualDepartureStation { get; set; }

        [JsonProperty("actualArrivalStation")]
        public ActualArrivalStation ActualArrivalStation { get; set; }

        [JsonProperty("actualdatetimeutc")]
        public Actualdatetimeutc Actualdatetimeutc { get; set; }

        [JsonProperty("scheduledArrivalStation")]
        public ScheduledArrivalStation ScheduledArrivalStation { get; set; }

        [JsonProperty("scheduledDepartureStation")]
        public ScheduledDepartureStation ScheduledDepartureStation { get; set; }

        [JsonProperty("codeShares")]
        public List<CodeShare> CodeShares { get; set; }

        [JsonProperty("aircraft")]
        public Aircraft Aircraft { get; set; }

        [JsonProperty("iataFlightServiceType")]
        public string IataFlightServiceType { get; set; }

        [JsonProperty("isETOPSFlight")]
        public bool IsETOPSFlight { get; set; }

        [JsonProperty("operatingAirlineCode")]
        public string OperatingAirlineCode { get; set; }

        [JsonProperty("operatingAirlineName")]
        public string OperatingAirlineName { get; set; }

        [JsonProperty("sourceInternalId")]
        public string SourceInternalId { get; set; }

        [JsonProperty("scheduledDepartureDateStnLocal")]
        public string ScheduledDepartureDateStnLocal { get; set; }
    }

    public class FlightDetails
    {
        [JsonProperty("sourceSystemName")]
        public string SourceSystemName { get; set; }

        [JsonProperty("sourceSystemLastModifiedDateTimeUtc")]
        public DateTime SourceSystemLastModifiedDateTimeUtc { get; set; }

        [JsonProperty("schemaVersion")]
        public string SchemaVersion { get; set; }

        [JsonProperty("lastEventType")]
        public string LastEventType { get; set; }

        [JsonProperty("operatingFlightNumber")]
        public string OperatingFlightNumber { get; set; }

        [JsonProperty("scheduledFlightOriginationDateUTC")]
        public string ScheduledFlightOriginationDateUTC { get; set; }

        [JsonProperty("scheduledFlightOriginationDateLocal")]
        public string ScheduledFlightOriginationDateLocal { get; set; }

        [JsonProperty("flightLegs")]
        public List<FlightLeg> FlightLegs { get; set; }
    }

    public class Flight
    {
        [JsonProperty("flightDetails")]
        public FlightDetails FlightDetails { get; set; }

        [JsonProperty("flightLookupKey")]
        public string FlightLookupKey { get; set; }

        [JsonProperty("updateCount")]
        public int UpdateCount { get; set; }
    }

    public class ActionResult
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("messages")]
        public List<string> Messages { get; set; }
    }

    public class FlightResponse
    {
        [JsonProperty("flights")]
        public List<Flight> Flights { get; set; }

        [JsonProperty("actionResult")]
        public ActionResult ActionResult { get; set; }
    }
}
