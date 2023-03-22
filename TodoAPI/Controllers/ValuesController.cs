using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController] // rest api
    public class ValuesController : ControllerBase
    {
        // data xml, json
        // status code -> http response message
        [HttpGet]
        public IActionResult notifyServer()
        {
            return Accepted(); // Ok() 
        }
    }
}
