using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAF.AirplaneTrafficDataModel.Models.TrafficDataManagement;

namespace DAF.AirplaneTrafficData.Repositories.Interfaces
{
    public interface IAirportRepository
    {
        void SaveArrivedAndDepartedFlightDetails(List<FlightDetails> flightList);

        Task<List<FlightDetails>> GetArrivedAndDepartedFlightDetails(string airportICAO, DateTime startDateTime,
            DateTime endDateTime);
    }
}