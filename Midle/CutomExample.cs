using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.Midle
{
    public class CutomExample
    {
        private readonly RequestDelegate next;

        public CutomExample(RequestDelegate _next)
        {
            next = _next;
        }

        public  async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request:{context.Request.Method} , {context.Request.Path}");
            await next(context);
            Console.WriteLine("Hello world");
            Console.WriteLine($"Response:{context.Response.StatusCode}");
        }
    }
}
