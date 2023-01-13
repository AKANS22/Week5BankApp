using System;
using System.Collections.Generic;
using System.Text;
using NewBank.Models.Abstractions;

namespace NewBank.Models.Implementations
{
    public class Transaction : ITransaction
    {
        public Transaction(string accountNumber, string description, string amount, decimal accountBalance, string date)
        {
            AccountNumber = accountNumber;
            Description = description;
            Amount = amount;
            AccountBalance = accountBalance;
            Date = date;
        }

        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
