using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    public class StartUp
    {
        public void Configure(IApplicationBuilder app)
        {
            Console.WriteLine("StartUp");
            // A sequência inserida é relevante

            //app.UseMiddleware<MyMiddleware>();
            app.UseMiddleware<ResponseTime>();
            
            // Esse código é um middle
            app.Run(context=>context.Response.WriteAsync("Hello"));
        }
    }
}