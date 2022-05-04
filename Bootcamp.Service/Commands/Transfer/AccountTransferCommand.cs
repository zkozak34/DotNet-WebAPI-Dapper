using Bootcamp.Core.Dtos.ResponseDto;
using MediatR;

namespace Bootcamp.Service.Commands.Transfer
{
    public class AccountTransferCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Amount { get; set; }
    }
}
