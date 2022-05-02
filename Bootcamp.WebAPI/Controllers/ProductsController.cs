using Bootcamp.WebAPI.Commands.Product.Add;
using Bootcamp.WebAPI.Commands.Product.Delete;
using Bootcamp.WebAPI.Commands.Product.Update;
using Bootcamp.WebAPI.Commands.Transfer;
using Bootcamp.WebAPI.Core.Aspects;
using Bootcamp.WebAPI.DTOs;
using Bootcamp.WebAPI.Filters;
using Bootcamp.WebAPI.Queries.Product.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        { 
            var response = await _mediator.Send(new ProductGetAllQuery());
            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }

        //[ServiceFilter(typeof(CheckProductIdActionFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new ProductGetByIdQuery() {Id = id});
            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto product)
        {
            var response = await _mediator.Send(new ProductAddCommand()
                {Name = product.Name, Price = product.Price, Stock = product.Stock, CategoryId = product.CategoryId});
            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }

        [ServiceFilter(typeof(CheckProductIdActionFilter))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new ProductDeleteCommand() {Id = id});
            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }

        [ServiceFilter(typeof(CheckProductIdActionFilter))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDto product)
        {
            var response = await _mediator.Send(new ProductUpdateCommand()
            {
                Id = id, Name = product.Name, Price = product.Price, Stock = product.Stock,
                CategoryId = product.CategoryId
            });
            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetWithPage([FromQuery] int page, int pagesize)
        {
            var response = await _mediator.Send(new ProductGetPageQuery() {Page = page, PageSize = pagesize});
            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferAccount(AccountTransferCommand accountTransferCommand)
        {
            var response = await _mediator.Send(accountTransferCommand);
            return new ObjectResult(response) {StatusCode = response.StatusCode};
        }
    }
}
