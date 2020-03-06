using Ares.Domain.Services;
using Ares.Infrastructure.FakeServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ares.Api.Middlewares
{
    public class MessageMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IMessageSender messageSender;

        public MessageMiddleware(RequestDelegate next, IMessageSender messageSender)
        {
            this.next = next;
            this.messageSender = messageSender;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string message = $"{context.Request.Method} {context.Request.Path}";

            messageSender.Send(message);

            await next.Invoke(context);

        }
    }



    public static class MessageMiddlewareExtensions
    {
        public static IApplicationBuilder UseMessage(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MessageMiddleware>();
        }


        public static IServiceCollection AddMessage(this IServiceCollection services)
        {
            return services.AddTransient<IMessageSender, SmsMessageSender>();
        }
    }
}
