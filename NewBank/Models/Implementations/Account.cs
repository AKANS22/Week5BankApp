using NewBank.Models.Abstractions;
using NewBank.Models.Enum;
using System.Collections.Generic;

namespace NewBank.Models.Implementations
{
    public class Account : IAccount
    {
        public Account(string accountNumber, string accountEmail, AccountTypes accountType, decimal balance)
        {
            AccountNumber = accountNumber;
            AccountEmail = accountEmail;
            AccountType = accountType;
            Balance = balance;
        }

        public string AccountNumber { get; set; }
        public string AccountEmail { get; set; }
        public AccountTypes AccountType { get; set; }
        public decimal Balance { get; set; }
        public List<ITransaction> TransactionHolder { get; set; } = new List<ITransaction>();
    }
}
