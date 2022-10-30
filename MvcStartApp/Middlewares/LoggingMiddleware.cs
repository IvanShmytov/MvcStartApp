using Microsoft.AspNetCore.Http;
using MvcStartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogRepository _logrepo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, ILogRepository logrepo)
        {
            _next = next;
            _logrepo = logrepo;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
            var req = new Request()
            {
                Id = new Guid(),
                Date = DateTime.Now,
                Url = $"{context.Request.Host.Value + context.Request.Path}"
            };
            await _logrepo.AddRequest(req);
            await _next.Invoke(context);
        }
    }
}
