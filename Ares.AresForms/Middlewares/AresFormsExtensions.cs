using Ares.Domain.Models;
using Ares.Domain.Services;
using Ares.Infrastructure.FakeServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Ares.AresForms.Middlewares
{
    public static class AresFormsExtensions
    {
        public static IServiceCollection AddAresForms(this IServiceCollection services)
        {
            services.AddTransient<IFormRepository, FakeFormRepository>();
            services.AddTransient<IVisitor, HtmlVisitor>();

            return services;
        }

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
}
