using NewBank.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace NewBank.Models.Abstractions
{
    public interface IAccount
    {
        string AccountNumber { get; set; }
        string AccountEmail { get; set; }
        AccountTypes AccountType { get; set; }
        decimal Balance { get; set; }
        List<ITransaction> TransactionHolder { get; set; }
    }
}
