using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NetCoreExampleApi
{
    public class Startup
    {
	public Startup(IConfiguration configuration)
	{
	    Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
	    services.AddControllers();
	    services.AddConfigOptions(Configuration);
	}

	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{

	    //app.UseCustomResponse();
	    //app.UseCustomResponseWithNext();
	    //app.Map("/map1", MiddlewareTest.HandleMap1);
	    //app.Map("/map2", MiddlewareTest.HandleMap2);
	    app.Map("/map1/seg1", MiddlewareTest.HandleMapWithMultipleSegements);
	    //app.MapWhen(context => context.Request.Query.ContainsKey("branch"), MiddlewareTest.HandleMapWhen);
	    app.UseWhen(context => context.Request.Query.ContainsKey("branch"), MiddlewareTest.HandleUseWhen);

	    if (env.IsDevelopment())
	    {
		app.UseDeveloperExceptionPage();
	    }

	    app.UseHttpsRedirection();

	    app.UseRouting();

	    app.UseAuthorization();

	    app.UseEndpoints(endpoints =>
	    {
		endpoints.MapControllers();
	    });

	}
    }
}
