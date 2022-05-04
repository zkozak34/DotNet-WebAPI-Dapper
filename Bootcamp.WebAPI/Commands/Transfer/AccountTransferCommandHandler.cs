using System.Data;
using Bootcamp.WebAPI.DTOs.ResponseDto;
using Bootcamp.WebAPI.Repositories;
using MediatR;

namespace Bootcamp.WebAPI.Commands.Transfer
{
    public class AccountTransferCommandHandler : IRequestHandler<AccountTransferCommand, ResponseDto<NoContent>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IDbTransaction _transaction;
        private readonly UnitOfWork _unitOfWork; // TODO: silinecek

        public AccountTransferCommandHandler(IProductRepository productRepository, IAccountRepository accountRepository, IDbTransaction transaction, UnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _accountRepository = accountRepository;
            _transaction = transaction;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<NoContent>> Handle(AccountTransferCommand request, CancellationToken cancellationToken)
        {
            //var response = await _productRepository.TransferByStoreProcedure(request);
            //var response = await _productRepository.Transfer(request);
            //if(response)
            //    return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            //return ResponseDto<NoContent>.Fail(StatusCodes.Status500InternalServerError);
            _productRepository.GetAll();
            await _accountRepository.Withdraw(request.Sender, 100);
            await _accountRepository.Deposit(request.Receiver, 100);
            //_transaction.Commit();
            _unitOfWork.Commit();
            return ResponseDto<NoContent>.Success(200);
        }
    }
}
