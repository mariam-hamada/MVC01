using System.Diagnostics;

namespace MVC01.CustomMiddleWare
{
    public class RequestTimingMiddleWare
    {
        public readonly RequestDelegate _next;
        RequestTimingMiddleWare(RequestDelegate next){
            next = _next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next.Invoke(context);
            watch.Stop();
            Console.WriteLine( watch.ElapsedMilliseconds);

        }

    }
}
