using NewBank.Models.Abstractions;
using System.Collections.Generic;

namespace NewBank.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        List<ICustomer> GetAllCustomers();
        bool Save(ICustomer customer);
        ICustomer Get(string email, string password);
    }
}