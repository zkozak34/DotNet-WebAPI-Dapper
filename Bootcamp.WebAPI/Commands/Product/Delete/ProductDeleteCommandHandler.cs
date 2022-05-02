using Bootcamp.WebAPI.DTOs.ResponseDto;
using Bootcamp.WebAPI.Repositories;
using MediatR;

namespace Bootcamp.WebAPI.Commands.Product.Delete
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly IProductRepository _productRepository;

        public ProductDeleteCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var responseFromDatabase = await _productRepository.Delete(request.Id);
            if (responseFromDatabase)
                return ResponseDto<NoContent>.Success(StatusCodes.Status204NoContent);
            return ResponseDto<NoContent>.Fail(StatusCodes.Status500InternalServerError);
        }
    }
}
