using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreExampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestConfigController : ControllerBase
    {
	private readonly IConfiguration _configuration;
	
	private readonly PostionOptions _postionOptions;

	public TestConfigController(IConfiguration configuration, IOptions<PostionOptions> postionOptions) 
	{
	    _configuration = configuration;
	    _postionOptions = postionOptions.Value;
	}

	[HttpGet("position/bind")]
	public IActionResult GetBindedPosition() 
	{
	    var positionOptions = new PostionOptions();
	    _configuration.GetSection(PostionOptions.Position).Bind(positionOptions);

	    return Ok($"Title: {positionOptions.Title} \n" +
		      $"Name: {positionOptions.Name}");
	}

	[HttpGet("position/bind-in-di-service")]
	public IActionResult GetBindedPositionFromService() 
	{
	    return Ok($"Title: {_postionOptions.Title} \n" +
		      $"Name: {_postionOptions.Name}");
	}

	[HttpGet]
	public IEnumerable<string> Get()
	{
	    return new string[] { "value1", "value2" };
	}

	// GET api/<TestConfigController>/5
	[HttpGet("{id}")]
	public string Get(int id)
	{
	    return "value";
	}

	// POST api/<TestConfigController>
	[HttpPost]
	public void Post([FromBody] string value)
	{
	}

	// PUT api/<TestConfigController>/5
	[HttpPut("{id}")]
	public void Put(int id, [FromBody] string value)
	{
	}

	// DELETE api/<TestConfigController>/5
	[HttpDelete("{id}")]
	public void Delete(int id)
	{
	}
    }
}
