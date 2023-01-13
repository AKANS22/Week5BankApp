using NewBank.Models.Abstractions;
using NewBank.Repositories;
using NewBank.Repositories.Abstractions;
using NewBank.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBank.Tables.Abstractions
{
    public interface IAccountDetails
    {
        List<IAccount> CustomerAccounts { get; set; }
        bool Generator(DIContainer dIContainer, ICustomer customer);
    }
}
