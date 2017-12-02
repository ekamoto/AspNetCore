using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    public class StartUp
    {
        public void Configure(IApplicationBuilder app)
        {
            // Adicionando uma função anonima
            app.Use(async(context, next) => {

                // Alterando a resposta da requisição
                context.Response.Headers.Add("Middleware", "Aprendendo");

                // Invocando o próximo Middle
                await next.Invoke();
            });


            // Esse código é um middle
            app.Run(context=>context.Response.WriteAsync("Hello"));
        }
    }
}