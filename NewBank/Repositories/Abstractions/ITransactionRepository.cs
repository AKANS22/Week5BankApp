using NewBank.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBank.Repositories.Abstractions
{
    public interface ITransactionRepository
    {
        bool Save(ITransaction transaction, IAccount account);
    }
}
