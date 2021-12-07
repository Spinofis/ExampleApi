using NetFrameworkExampleApi.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace NetFrameworkExampleApi.Controllers
{
    public class EfTestsController : ApiController
    {
        private EFtestsService efTestsService = new EFtestsService();


        [HttpGet]
        [Route("test-concurrent-update/{amount}/{waitBeforeUpdateMs}")]
        public async Task<IHttpActionResult> TestConCurrentUpdate(decimal amount, int waitBeforeUpdateMs)
        {
            await efTestsService.TestConccurencyUpdate(amount, waitBeforeUpdateMs);
            return Ok();
        }
    }
}