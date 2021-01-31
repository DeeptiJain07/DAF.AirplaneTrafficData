using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAF.AirplaneTrafficData.Extensions.Interfaces;
using DAF.AirplaneTrafficData.HelperClasses;
using DAF.AirplaneTrafficData.Models;
using DAF.AirplaneTrafficData.Repositories.Interfaces;
using DAF.AirplaneTrafficData.Services.Interfaces;
using DAF.AirplaneTrafficDataModel.Models.TrafficDataManagement;
using Newtonsoft.Json;

namespace DAF.AirplaneTrafficData.Services
{
    public class AirportService : IAirportService
    {
        private readonly IHttpClientFactoryExtension _httpClientFactoryExtension;
        private readonly IAirportRepository _airportRepository;
        private const int SecondsInSevenDays = 7 * 24 * 60 * 60;

        public AirportService(IHttpClientFactoryExtension httpClientFactoryExtension, IAirportRepository airportRepository)
        {
            _httpClientFactoryExtension = httpClientFactoryExtension;
            _airportRepository = airportRepository;
        }

        /// <summary>
        /// gets data of the arriving and departing aircrafts on given airport
        /// </summary>
        /// <param name="airportICAO"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public async Task<List<FlightDetails>> GetAircraftListByAirport(string airportICAO, DateTime startTime, DateTime endTime)
        {
            return await _airportRepository.GetArrivedAndDepartedFlightDetails(airportICAO, startTime, endTime);
        }

        /// <summary>
        /// Collects data of the arriving and departing aircrafts on given airport from Open Sky and save in database
        /// </summary>
        /// <param name="airportICAO"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public async Task<bool> SaveFlightDetailsByAirport(string airportICAO, DateTime startTime, DateTime endTime)
        {
            if ((endTime - startTime).TotalSeconds > SecondsInSevenDays)
                return await Task.Run(() => false);

            var startTimeSpan = (startTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));
            var unixStartTime = startTimeSpan.TotalSeconds;

            var endTimeSpan = (endTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));
            var unixEndTime = endTimeSpan.TotalSeconds;

            var arrivalUrl = $"/flights/arrival?airport={airportICAO}&begin={unixStartTime}&end={unixEndTime}";

            var arrivalResult = await _httpClientFactoryExtension.GetResponseFromEndpointTask<List<Flight>>(
                new HttpEndpointTypes
                {
                    ServiceEndPoint = "https://opensky-network.org",
                    ClientEndPoint = "DafServiceEndPoint",
                    UrlParameters = arrivalUrl
                });

            var departureUrl = $"/flights/departure?airport={airportICAO}&begin={unixStartTime}&end={unixEndTime}";

            var departureResult = await _httpClientFactoryExtension.GetResponseFromEndpointTask<List<Flight>>(
                new HttpEndpointTypes
                {
                    ServiceEndPoint = "https://opensky-network.org",
                    ClientEndPoint = "DafServiceEndPoint",
                    UrlParameters = departureUrl
                });

            var flightDetailsOnAirport = new List<Flight>();

            if (arrivalResult != null && arrivalResult.Count > 0)
            {
                flightDetailsOnAirport.AddRange(arrivalResult);
            }

            if (departureResult != null && departureResult.Count > 0)
            {
                flightDetailsOnAirport.AddRange(departureResult);
            }

            var flightList = flightDetailsOnAirport.Select(i =>
                new FlightDetails()
                {
                    FlightICAO24 = i.Icao24,
                    ArrivalAirportICAO = i.EstArrivalAirport,
                    DepartureAirportICAO = i.EstDepartureAirport,
                    EstimatedArrivalTime = Common.UnixTimeStampToDateTime(i.LastSeen),
                    EstimatedDepartureTime = Common.UnixTimeStampToDateTime(i.FirstSeen)
                }).ToList<FlightDetails>();

            _airportRepository.SaveArrivedAndDepartedFlightDetails(flightList);

            return await Task.Run(() => true);
        }
    }
}