using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExampleApi
{
    public static class MiddlewareTest
    {
        public static void UseCustomResponse(this IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello, World!");
            });
        }

        public static void UseCustomResponseWithNext(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
            // Do work that doesn't write to the Response.
            //await next.Invoke();
            // Do logging or other work that doesn't write to the Response.
        });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 2nd delegate.");
            });
        }

        public static void HandleMap1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }

        public static void HandleMap2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 2");
            });
        }

        public static void HandleMapWithMultipleSegements(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map multiple segments.");
            });
        }

        public static void HandleMapWhen(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var branchVer = context.Request.Query["branch"];
                await context.Response.WriteAsync($"Branch used = {branchVer}");
            });
        }

        public static void HandleUseWhen(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var branchVer = context.Request.Query["branch"];
                await context.Response.WriteAsync($"Use when middleware. Branch used = {branchVer}");
                await next();
            });
        }
    }
}
