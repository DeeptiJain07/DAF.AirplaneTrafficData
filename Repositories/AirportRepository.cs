using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAF.AirplaneTrafficData.Repositories.Interfaces;
using DAF.AirplaneTrafficDataModel.Models.TrafficDataManagement;
using Microsoft.EntityFrameworkCore;

namespace DAF.AirplaneTrafficData.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly TrafficDataManagementContext _trafficDataManagementContext;

        public AirportRepository(TrafficDataManagementContext trafficDataManagementContext)
        {
            _trafficDataManagementContext = trafficDataManagementContext;
        }

        public void SaveArrivedAndDepartedFlightDetails(List<FlightDetails> flightList)
        {
            _trafficDataManagementContext.FlightDetails.AddRange(flightList);
            _trafficDataManagementContext.SaveChanges();
        }

        public async Task<List<FlightDetails>> GetArrivedAndDepartedFlightDetails(string airportICAO, DateTime startDateTime,
            DateTime endDateTime)
        {
            var flightList = await _trafficDataManagementContext.FlightDetails.Where(i =>
                (i.ArrivalAirportICAO == airportICAO || i.DepartureAirportICAO == airportICAO) &&
                ((i.EstimatedDepartureTime <= endDateTime && i.EstimatedDepartureTime >= startDateTime) ||
                 (i.EstimatedArrivalTime <= endDateTime && i.EstimatedArrivalTime >= startDateTime))).ToListAsync();

            return flightList ?? null;
        }
    }
}