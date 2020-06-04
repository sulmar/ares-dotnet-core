using Ares.Domain.Models;
using Ares.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Ares.AresForms.Middlewares
{
    public class AresFormsOptions
    {
        public PathString Path { get; set; }
    }


    public static class AresFormsExtensions
    {
        public static IApplicationBuilder UseAresForms(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<AresFormsMiddleware>();
        }

        public static IApplicationBuilder UseAresForms(this IApplicationBuilder app, AresFormsOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<AresFormsMiddleware>(Options.Create(options));
        }

        public static IApplicationBuilder UseAresForms(this IApplicationBuilder app, PathString path)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseAresForms(new AresFormsOptions
            {
                Path = path
            });
        }
    }


    public class AresFormsMiddleware
    {
        private readonly RequestDelegate next;

        private readonly IFormRepository formRepository;
        private readonly IVisitor visitor;
        private readonly AresFormsOptions options;

        public AresFormsMiddleware(RequestDelegate next, IFormRepository formRepository, IVisitor visitor, IOptions<AresFormsOptions> options)
        {
            this.formRepository = formRepository;
            this.visitor = visitor;
            this.next = next;
            this.options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Trace.WriteLine($"{context.Request.Method} {context.Request.Path}");

            if (!options.Path.HasValue || context.Request.Path.StartsWithSegments(options.Path))
            {
                if (context.Request.Method == "GET")
                {
                    Form form = formRepository.Get(context.Request.Path);

                    if (form != null)
                    {
                        form.Accept(visitor);

                        string html = visitor.Output;

                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync(html);
                    }
                }
                else
                if (context.Request.Method == "POST")
                {
                    if (context.Request.HasFormContentType)
                    {
                        IFormCollection form = await context.Request.ReadFormAsync(); // async

                        string param1 = form["param1"];
                        string param2 = form["param2"];

                    }
                }
            }

           


        }
    }
}
