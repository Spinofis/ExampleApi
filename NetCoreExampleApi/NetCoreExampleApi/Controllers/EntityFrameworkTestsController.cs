using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreExampleApi.BusinessLogic;

namespace NetCoreExampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityFrameworkTestsController : ControllerBase
    {
        private readonly IEntityFrameworkTests efTests;

        public EntityFrameworkTestsController(IEntityFrameworkTests tests) { efTests = tests; }

        [HttpGet("test-concurrent-update/{amount}/{waitBeforeUpdateMs}")]
        public async Task<IActionResult> TestConCurrentUpdate(decimal amount, int waitBeforeUpdateMs)
        {
            await efTests.TestConccurencyUpdate(amount, waitBeforeUpdateMs);
            return Ok();
        }
    }
}
