using Newtonsoft.Json;

namespace DAF.AirplaneTrafficData.Models
{
    public class Flight
    {
        [JsonProperty(PropertyName = "icao24")]
        public string Icao24 { get; set; }

        [JsonProperty(PropertyName = "firstSeen")]
        public int? FirstSeen { get; set; }

        [JsonProperty(PropertyName = "estDepartureAirport")]
        public string EstDepartureAirport { get; set; }

        [JsonProperty(PropertyName = "lastSeen")]
        public int? LastSeen { get; set; }

        [JsonProperty(PropertyName = "estArrivalAirport")]
        public string EstArrivalAirport { get; set; }

        [JsonProperty(PropertyName = "callsign")]
        public string Callsign { get; set; }

        [JsonProperty(PropertyName = "estDepartureAirportHorizDistance")]
        public int? EstDepartureAirportHorizDistance { get; set; }

        [JsonProperty(PropertyName = "estDepartureAirportVertDistance")]
        public int? EstDepartureAirportVertDistance { get; set; }

        [JsonProperty(PropertyName = "estArrivalAirportHorizDistance")]
        public int? EstArrivalAirportHorizDistance { get; set; }

        [JsonProperty(PropertyName = "estArrivalAirportVertDistance")]
        public int? EstArrivalAirportVertDistance { get; set; }

        [JsonProperty(PropertyName = "departureAirportCandidatesCount")]
        public int? DepartureAirportCandidatesCount { get; set; }

        [JsonProperty(PropertyName = "arrivalAirportCandidatesCount")]
        public int? ArrivalAirportCandidatesCount { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Icao24)}: {Icao24}, {nameof(FirstSeen)}: {FirstSeen}, {nameof(EstDepartureAirport)}: {EstDepartureAirport}, {nameof(LastSeen)}: {LastSeen}, {nameof(EstArrivalAirport)}: {EstArrivalAirport}, {nameof(Callsign)}: {Callsign}, {nameof(EstDepartureAirportHorizDistance)}: {EstDepartureAirportHorizDistance}, {nameof(EstDepartureAirportVertDistance)}: {EstDepartureAirportVertDistance}, {nameof(EstArrivalAirportHorizDistance)}: {EstArrivalAirportHorizDistance}, {nameof(EstArrivalAirportVertDistance)}: {EstArrivalAirportVertDistance}, {nameof(DepartureAirportCandidatesCount)}: {DepartureAirportCandidatesCount}, {nameof(ArrivalAirportCandidatesCount)}: {ArrivalAirportCandidatesCount}";
        }
    }
}