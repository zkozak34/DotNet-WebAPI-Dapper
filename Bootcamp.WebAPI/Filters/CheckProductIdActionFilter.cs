using Bootcamp.Core.Dtos.ResponseDto;
using Bootcamp.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bootcamp.WebAPI.Filters
{
    public class CheckProductIdActionFilter : ActionFilterAttribute
    {
        private readonly IProductRepository _productRepository;

        public CheckProductIdActionFilter(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = int.Parse(context.HttpContext.Request.RouteValues["id"]!.ToString()!);
            var hasProduct = await _productRepository.GetById(id);
            if (hasProduct != null)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(ResponseDto<NoContent>.Fail($"{id} bulunamadı.", StatusCodes.Status404NotFound));
        }
    }
}
