using Microsoft.AspNetCore.Mvc;

namespace MicroserviciosNetCore3.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Running ...";
        }
    }
}
