using Bootcamp.Core.Dtos.ResponseDto;
using Bootcamp.Repository.Repositories;
using MediatR;

namespace Bootcamp.Service.Commands.Product.Delete
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
                return ResponseDto<NoContent>.Success(204);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
