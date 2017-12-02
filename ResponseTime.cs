using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    public class ResponseTime
    {
        private RequestDelegate _next;

        public ResponseTime(RequestDelegate next)
        {
            
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            Console.WriteLine("ResponseTime");

            var sw = new Stopwatch();
            sw.Start();

            Console.WriteLine("Request");
            await _next(context);

            var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");

            Console.WriteLine($"contentType: {context.Response.ContentType}");
            Console.WriteLine($"StatusCode: {context.Response.StatusCode} - isHtml:{isHtml.GetValueOrDefault()}");

            if(context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
            {
                Console.WriteLine("Entrou no if");
                var body = context.Response.Body;

                using(var streamWriter = new StreamWriter(body)) {
                    
                    var textHtml = string.Format("<footer><div id = 'process'>Response time {0} milliseconds.</div></footer>",
                    sw.ElapsedMilliseconds);
                    Console.WriteLine("Response");
                    streamWriter.Write(textHtml);
                }
            }
        }
    }
}