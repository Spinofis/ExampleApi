using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestRoutingController : ControllerBase
    {
        [HttpGet("foo/{**slug}")]
        public IActionResult Foo(string slug)
        {
            return Ok(slug);
        }

        [HttpGet("foo2/{*slug}")]
        public IActionResult Foo2(string slug)
        {
            return Ok(slug);
        }
    }
}
