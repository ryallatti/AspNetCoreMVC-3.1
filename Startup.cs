using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //adding MVC  to application 
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async(context, next) =>
            //{
            //    await context.Response.WriteAsync("hello its my first middleware");
              
            //     //Calling next middleware
            //    // await next();
            //});
            
            //Enabling Routing 
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // "/" indicates root folder
                //endpoints.Map("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

               // this routing  points default to the Home controller
                endpoints.MapDefaultControllerRoute();
            });
            //Custom middleware
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.Map("/Rekha", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Rekha!");
            //    });
            //});
        }
    }
}
