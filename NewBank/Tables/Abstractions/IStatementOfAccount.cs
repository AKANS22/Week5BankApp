using NewBank.Models.Abstractions;
using NewBank.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBank.Tables.Abstractions
{
    public interface IStatementOfAccount
    {
        List<ITransaction> AccountTransactions { get; set; }
        bool Generator(DIContainer dIContainer, ICustomer customer);
    }
}
