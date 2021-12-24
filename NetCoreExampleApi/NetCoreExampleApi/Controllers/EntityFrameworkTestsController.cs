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

        [HttpPatch("add-amount/{accountId}/{amount}/{waitBeforeUpdateMs}")]
        public async Task<IActionResult> AddAmount(int accountId, decimal amount, int waitBeforeUpdateMs)
        {
            await efTests.AddAmount(accountId, amount, waitBeforeUpdateMs);
            return Ok();
        }

        [HttpPatch("update-product/{productId}/{quantity}/{waitBeforeUpdateMs}")]
        public async Task<IActionResult> UpdateQuantity(int productId, int quantity, int waitBeforeUpdateMs)
        {
            await efTests.UpdateProduct(productId, quantity, waitBeforeUpdateMs);
            return Ok();
        }
    }
}
