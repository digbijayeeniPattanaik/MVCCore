using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CustomerApplication
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware2
    {
        private readonly RequestDelegate _next;

        public Middleware2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Test Method 4");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Middleware2Extensions
    {
        public static IApplicationBuilder UseMiddleware2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware2>();
        }
    }
}
