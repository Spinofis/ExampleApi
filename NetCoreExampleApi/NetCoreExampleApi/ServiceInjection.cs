using Database;
using Microsoft.EntityFrameworkCore;
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
            services.AddSingleton<TestService2>();
            services.AddScoped<ITestService, TestService>(); // y y n
            services.AddScoped<ITestService>((serviceProvider) => new TestService(3)); //  y y y
            services.AddScoped<TestService>(); //y n n

            services.AddScoped<IEntityFrameworkTests, EntityFrameworkTests>();
        }

        public static void AddConfigOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PostionOptions>(configuration.GetSection(PostionOptions.Position));
        }

        public static void AddExampleDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExampleContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("ExampleConnection")));
        }
    }
}
