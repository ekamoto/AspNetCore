using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace hosting
{
    public class StartUp
    {
        public IConfiguration Configuration { get;set; }

        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app)
        {
            Console.WriteLine("StartUp");
            // A sequência inserida é relevante

            var applicationName = Configuration.GetValue<string>("ApplicationName");

            //app.UseMiddleware<MyMiddleware>();
            app.UseMiddleware<ResponseTime>();
            app.UseStaticFiles();
            
            // Esse código é um middle
            app.Run(context=>context.Response.WriteAsync($"Hello ApplicationName: {applicationName}"));
        }
    }
}