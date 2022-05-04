using Bootcamp.Core.Dtos.ResponseDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bootcamp.WebAPI.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.Result = new ObjectResult(ResponseDto<NoContent>.Fail(context.Exception.Message, StatusCodes.Status500InternalServerError)) { StatusCode = StatusCodes.Status500InternalServerError };
            return base.OnExceptionAsync(context);
        }
    }
}
