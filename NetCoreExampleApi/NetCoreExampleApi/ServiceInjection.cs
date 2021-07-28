using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreExampleApi.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExampleApi
{
    public static class ServiceInjection
    {
	public static void AddTestServices(this IServiceCollection services)
	{
	    services.AddScoped<ITestService, TestService>(); // y y n
	    services.AddScoped<ITestService>((serviceProvider) => new TestService(3)); //  y y y
	    services.AddScoped<TestService>(); //y n n
	}

	public static void AddConfigOptions(this IServiceCollection services, IConfiguration configuration) 
	{
	    services.Configure<PostionOptions>(configuration.GetSection(PostionOptions.Position));
	}
    }
}
