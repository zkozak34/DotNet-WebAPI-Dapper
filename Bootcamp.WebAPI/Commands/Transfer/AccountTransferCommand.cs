using Bootcamp.WebAPI.DTOs.ResponseDto;
using MediatR;

namespace Bootcamp.WebAPI.Commands.Transfer
{
    public class AccountTransferCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Amount { get; set; }
    }
}
