using Bootcamp.WebAPI.DTOs.ResponseDto;
using MediatR;

namespace Bootcamp.WebAPI.Queries.Product.Get
{
    public class ProductGetByIdQuery : IRequest<ResponseDto<Models.Product>>
    {
        public int Id { get; set; }
    }
}
