using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NetFrameworkExampleApi.Controllers
{
    public class TestAsyncController : ApiController
    {
	[HttpGet]
	[Route("api/testasync/configure-await")]
	public IHttpActionResult ConfigureAwait() 
	{
	    string s = DoCurlAsync(false).Result;
	    return Ok(s);
	}

	[HttpGet]
	[Route("api/testasync/no-configure-await")]
	public IHttpActionResult NoConfigureAwait()
	{
	    string s = DoCurlAsync(true).Result;
	    return Ok(s); 
	}

	public async Task<string> DoCurlAsync(bool configureAwait)
	{
	    using (var httpClient = new HttpClient())
	    using (var httpResonse = await httpClient.GetAsync("https://www.bynder.com").ConfigureAwait(configureAwait))
	    {
		return await httpResonse.Content.ReadAsStringAsync();
	    }
	}
    }
}
