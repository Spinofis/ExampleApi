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

        [HttpGet("env/test-env")]
        public IActionResult GetTestEnviVariable() 
        {
            return Ok(Environment.GetEnvironmentVariable("TEST_ENV"));
        }

        [HttpGet("env/config-test-env1")]
        public IActionResult GetTestConfigVariable()
        {
            return Ok(_configuration["test_env1"]);
        }

	[HttpGet("config/get-children-test")]
	public IActionResult GetChildrenTest() 
	{
	    string s = null;
	    var section2 = _configuration.GetSection("section2");
	    if (!section2.Exists()) 
	    {
		throw new InvalidOperationException("There is no such section section2!");
	    }
	    var children = section2.GetChildren();
	    foreach (var subSection in children)
	    {
		int i = 0;
		var key1 = subSection.Key + ":key" + i++.ToString();
		var key2 = subSection.Key + ":key" + i.ToString();
		s += key1 + " value: " + section2[key1] + "\n";
		s += key2 + " value: " + section2[key2] + "\n";
	    }
	    return Ok(s);
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
