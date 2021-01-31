using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAF.AirplaneTrafficDataModel.Models.TrafficDataManagement;

namespace DAF.AirplaneTrafficData.Services.Interfaces
{
    public interface IAirportService
    {
        Task<List<FlightDetails>> GetAircraftListByAirport(string airportICAO, DateTime startTime, DateTime endTime);

        Task<bool> SaveFlightDetailsByAirport(string airportICAO, DateTime startTime, DateTime endTime);
    }
}