using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio");
            var host = new WebHostBuilder().
                        UseKestrel()
                        .UseStartup<StartUp>()
                        .Build();
            host.Run();    
        }
    }
}