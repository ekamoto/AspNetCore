using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace hosting
{
    class Program
    {
        static void Main(string[] args)
        {
          BuildWebHost(args).Run();  
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<StartUp>()
            .Build();
    }
}