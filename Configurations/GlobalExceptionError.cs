using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace WebApplication1.Configurations
{
    public static class GlobalExceptionError
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        context.Response.StatusCode = (exceptionHandlerFeature.Error is ValidationException)
                            ? (int)HttpStatusCode.BadRequest
                            : (int)HttpStatusCode.InternalServerError;

                        context.Response.ContentType = "application/json";

                        var json = new
                        {
                            context.Response.StatusCode,
                            Message = "An error occurred whilst processing your request",
                            Detailed = exceptionHandlerFeature.Error
                        };

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(json));
                    }
                });
            });
        }

    }
}
