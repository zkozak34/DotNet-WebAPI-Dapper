using Bootcamp.Core.Dtos.ResponseDto;
using Microsoft.AspNetCore.Diagnostics;

namespace Bootcamp.WebAPI.Middlewares
{
    public static class GlobalExceptionHandlerMiddleware
    {
        public static void UseGlobalExceptionHandleMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionFeature.Error;
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsJsonAsync<ResponseDto<NoContent>>(ResponseDto<NoContent>.Fail(exception.Message, StatusCodes.Status500InternalServerError));
                });
            });
        }
    }
}
