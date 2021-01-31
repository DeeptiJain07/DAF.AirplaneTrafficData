using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DAF.AirplaneTrafficData.Controllers
{
    [EnableCors("DafAirplane")]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json", "application/xml")] //response format
    [Consumes("application/json", "application/xml")] //request format 
    public class BaseController : Controller
    {
    }
}