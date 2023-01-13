using NewBank.Models.Abstractions;
using NewBank.Repositories;

namespace NewBank.Services.Abstractions
{

    public interface IAccountServices
    {
        string Amount { get; set; }
        IAccount Account { get; set; }
        IAccount OtherAccount { get; set; }

        string CheckBalance(DIContainer dIContainer, ICustomer customer, string email);
        bool Deposit(DIContainer dIContainer, ICustomer customer, string email);
        bool Transfer(DIContainer dIContainer, ICustomer customer, string email);
        bool Withdraw(DIContainer dIContainer, ICustomer customer, string email);
    }
}