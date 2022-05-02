using AutoMapper;
using Bootcamp.WebAPI.DTOs.ResponseDto;
using Bootcamp.WebAPI.Repositories;
using MediatR;

namespace Bootcamp.WebAPI.Commands.Product.Add
{
    public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand, ResponseDto<NoContent>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductAddCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<NoContent>> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            var responseFromDatabase = await _productRepository.Save(new Models.Product() {Name = request.Name, Price = request.Price, Stock = request.Stock, CategoryId = request.CategoryId});
            //ISubject subject = new ProductCreated();
            //subject.Attach(new EmailObserver());
            //subject.Notify();
            //_mediator.Publish(new ProductCreatedEvent(){Id = lastId,Name = request.Name});
            if (responseFromDatabase)
                return ResponseDto<NoContent>.Success(StatusCodes.Status204NoContent);
            return ResponseDto<NoContent>.Fail(StatusCodes.Status500InternalServerError);
        }
    }
}
