using Bootcamp.Core.Dtos.ResponseDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bootcamp.WebAPI.Filters
{
    public class ValidateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result =
                    new BadRequestObjectResult(ResponseDto<NoContent>.Fail(errors, StatusCodes.Status400BadRequest));
            }
        }
    }
}
