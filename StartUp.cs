using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    public class StartUp
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(context=>context.Response.WriteAsync("Hello"));
        }
    }
}