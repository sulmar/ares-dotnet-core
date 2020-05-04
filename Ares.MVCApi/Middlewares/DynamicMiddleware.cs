using Ares.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ares.MVCApi.Middlewares
{


    public class DynamicMiddleware
    {
        private readonly RequestDelegate next;

        private readonly ILogger<DynamicMiddleware> logger;

        public DynamicMiddleware(RequestDelegate next, ILogger<DynamicMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

       //  http://localhost/api/code/customers/10

        public async Task InvokeAsync(HttpContext context)
        {
            if ( context.Request.Path.StartsWithSegments("/api/code"))
            {

                var  r = context.Request.RouteValues;


                dynamic model = new Customer { FirstName = "Marcin" };


                string accept = context.Request.Headers["Accept"].First();

                string json = JsonConvert.SerializeObject(model);

                 context.Response.Headers.Add("Content-Type",  new Microsoft.Extensions.Primitives.StringValues("application/json"));

                await context.Response.WriteAsync(json);
            }
            else
            {
                await next(context);
            }
        }
    }
}
