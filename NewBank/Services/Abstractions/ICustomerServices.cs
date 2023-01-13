using NewBank.Models.Abstractions;
using NewBank.Repositories;

namespace NewBank.Services.Abstractions
{
    public interface ICustomerServices : ICustomer, IAccount
    {
        bool CreateCustomer(DIContainer dIContainer);
        bool CreateAccount(DIContainer dIContainer, ICustomer customer);
        bool Login(DIContainer dIContainer);
    }
}