using AutoMapper;
using Bootcamp.Core.Dtos.ResponseDto;
using Bootcamp.Repository.Repositories;
using MediatR;

namespace Bootcamp.Service.Commands.Product.Add
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
            var responseFromDatabase = await _productRepository.Save(new Entities.Entities.Concrete.Product() { Name = request.Name, Price = request.Price, Stock = request.Stock, CategoryId = request.CategoryId });
            //ISubject subject = new ProductCreated();
            //subject.Attach(new EmailObserver());
            //subject.Notify();
            //_mediator.Publish(new ProductCreatedEvent(){Id = lastId,Name = request.Name});
            if (responseFromDatabase)
                return ResponseDto<NoContent>.Success(204);
            return ResponseDto<NoContent>.Fail(500);
        }
    }
}
