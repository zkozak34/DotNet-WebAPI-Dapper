using Bootcamp.Core.Dtos.ResponseDto;
using Bootcamp.Repository.Abstract;
using MediatR;

namespace Bootcamp.Service.Commands.Product.Update
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
            var responseFromDatabase = await _productRepository.Update(new() { Id = request.Id, Name = request.Name, Price = request.Price, Stock = request.Stock, CategoryId = request.CategoryId });
            if (responseFromDatabase)
                return ResponseDto<NoContent>.Success(204);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
