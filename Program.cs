using System;
using System.IO;
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
                        .UseContentRoot(Directory.GetCurrentDirectory())//Avisando o host que tem conteúdo na raiz que será utilizado
                        .Build();
            host.Run();    
        }
    }
}