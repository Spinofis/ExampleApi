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


        [HttpPatch]
        [Route("add-amount/{accountId}/{amount}/{waitBeforeUpdateMs}")]
        public async Task<IHttpActionResult> AddAmount(int accountId, decimal amount, int waitBeforeUpdateMs)
        {
            await efTestsService.AddAmount(accountId, amount, waitBeforeUpdateMs);
            return Ok();
        }

        [HttpPatch]
        [Route("update-product/{productId}/{quantity}/{waitBeforeUpdateMs}")]
        public async Task<IHttpActionResult> UpdateQuantity(int productId, int quantity, int waitBeforeUpdateMs)
        {
            await efTestsService.UpdateProduct(productId, quantity, waitBeforeUpdateMs);
            return Ok();
        }

        [HttpGet]
        [Route("fixup-query")]
        public async Task<IHttpActionResult> TestFixUpQuery()
        {
            efTestsService.TestFixUpQuery();
            return Ok();
        }
    }
}