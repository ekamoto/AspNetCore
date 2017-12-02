using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    public class StartUp
    {
        public void Configure(IApplicationBuilder app)
        {
            // A sequência inserida é relevante

            app.UseMiddleware<MyMiddleware>();

            // Esse código é um middle
            app.Run(context=>context.Response.WriteAsync("Hello | "));
        }
    }
}