using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAF.AirplaneTrafficData.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAF.AirplaneTrafficData.Controllers
{
    [Route("api/airport")]
    [ApiController]
    public class AirportController : BaseController
    {
        private readonly IAirportService _airportService;

        public AirportController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        /// <summary>
        ///     Gets the list of aircrafts by airport
        /// </summary>
        /// <param name="airportICAO"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [HttpGet("aircrafts/{airportICAO}/{startTime}/{endTime}")]
        public async Task<IActionResult> GetAircraftListByAirport ([FromQuery] string airportICAO, DateTime startTime, DateTime endTime)
        {
            var aircraftList = await _airportService.GetAircraftListByAirport(airportICAO, startTime, endTime);

            return new OkObjectResult(aircraftList);
        }

        /// <summary>
        /// Save flight details by airport
        /// </summary>
        /// <param name="airportICAO"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [HttpPost("aircrafts/{airportICAO}/{startTime}/{endTime}")]
        public async Task<IActionResult> SaveFlightDetailsByAirport([FromQuery] string airportICAO, DateTime startTime, DateTime endTime)
        {
            var response = await _airportService.SaveFlightDetailsByAirport(airportICAO, startTime, endTime);

            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }
    }
}