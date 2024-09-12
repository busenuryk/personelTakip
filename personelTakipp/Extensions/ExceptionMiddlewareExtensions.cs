using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace personelTakipp.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void CongifureExcepctionHandler(this WebApplication app,
            ILogger logger)
        {
            app.UseExceptionHandler(appErr =>
            {
                appErr.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); //hata varsa yakalıyooruz
                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError("Something went wrong"); //hata varsa log alıyoruz
                        await context.Response.WriteAsync(new ErrorDetails() //hatayı yazıyoruz
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
