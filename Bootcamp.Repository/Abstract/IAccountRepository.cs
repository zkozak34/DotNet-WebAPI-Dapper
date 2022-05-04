namespace Bootcamp.Repository.Abstract
{
    public interface IAccountRepository
    {
        Task<bool> Deposit(int userId, decimal amount);
        Task<bool> Withdraw(int userId, decimal amount);
    }
}
