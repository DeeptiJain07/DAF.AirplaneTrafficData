using DAF.AirplaneTrafficData.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DAF.AirplaneTrafficData.Controllers
{
    [Route("api/aircraft")]
    [ApiController]
    public class AircraftController : BaseController
    {
        private readonly IAircraftService _aircraftService;

        public AircraftController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }
    }
}