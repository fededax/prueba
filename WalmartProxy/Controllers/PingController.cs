using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WalmartProxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        // GET api/ping
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "pong" };
        }

        // POST api/ping
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return "pong";
        }
    }
}
