using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace hosting
{
    public class StartUp
    {
        private IConfigurationRoot _configuration;

        public StartUp(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json");

            builder.AddEnvironmentVariables();

            _configuration = builder.Build();

        }

        public void Configure(IApplicationBuilder app)
        {
            Console.WriteLine("StartUp");
            // A sequência inserida é relevante

            var applicationName = _configuration.GetValue<string>("ApplicationName");

            //app.UseMiddleware<MyMiddleware>();
            app.UseMiddleware<ResponseTime>();
            
            // Esse código é um middle
            app.Run(context=>context.Response.WriteAsync($"Hello ApplicationName: {applicationName}"));
        }
    }
}