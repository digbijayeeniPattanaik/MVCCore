using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      
        ////public void Configure(IApplicationBuilder app)
        ////{
        ////    app.Map("/home", ExecuteHome);
        ////    app.MapWhen(context => 
        ////    {
        ////        return context.Request.Query.ContainsKey("Search");
        ////    }, ExecuteSearch);

        ////    app.UseMiddleware2();
        ////    app.Use(async (context, next) => await Method2(context, next));
        ////    ////app.Use(async (context, next) => await Method1(context, next));
        ////    app.UseMiddleware<Middleware>();
        ////    app.Run(async (context) => await Method3(context));
        ////}

        private void ExecuteHome(IApplicationBuilder app)
        {
            app.Run(async (context) => await context.Response.WriteAsync("Home is running"));
        }
        private void ExecuteSearch(IApplicationBuilder app)
        {
            app.Run(async (context) => await context.Response.WriteAsync("Search is running"));
        }

        private async Task Method1(HttpContext httpContext, Func<Task> next)
        {
            await httpContext.Response.WriteAsync("Test Method 1");
            await next.Invoke();
        }

        private async Task Method2(HttpContext httpContext, Func<Task> next)
        {
            await httpContext.Response.WriteAsync("Test Method 2");
            await next.Invoke();
        }

        private async Task Method3(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Test Method 3");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                ////routes.MapRoute(
                ////    name: "",
                ////    template: "{controller=Customer}/{action=Add}");
            });
        }
    }
}
