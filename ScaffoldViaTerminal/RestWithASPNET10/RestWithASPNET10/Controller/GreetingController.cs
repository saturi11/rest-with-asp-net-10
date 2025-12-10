using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Model;

namespace RestWithASPNET10.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private static long _contrer = 0;
        private static readonly string _template = "Hello World from ASP.NET Core 10, {0}";

        [HttpGet]
        public Greeting Get([FromQuery] string name = "Hello World from ASP.NET Core 10")
        {
            var id = Interlocked.Increment(ref _contrer);
            var content = string.Format(_template, name);
            return new Greeting(1, content);
        }
    }
}
