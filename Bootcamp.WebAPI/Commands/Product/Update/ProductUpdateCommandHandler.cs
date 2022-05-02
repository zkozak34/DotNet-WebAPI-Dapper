using Bootcamp.WebAPI.DTOs.ResponseDto;
using Bootcamp.WebAPI.Repositories;
using MediatR;

namespace Bootcamp.WebAPI.Commands.Product.Update
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var responseFromDatabase = await _productRepository.Update(new() { Id = request.Id, Name = request.Name, Price = request.Price, Stock = request.Stock, CategoryId = request.CategoryId});
            if(responseFromDatabase)
                return ResponseDto<NoContent>.Success(StatusCodes.Status204NoContent);
            return ResponseDto<NoContent>.Fail(StatusCodes.Status500InternalServerError);
        }
    }
}
