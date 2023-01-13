using NewBank.Models.Abstractions;
using NewBank.Repositories;
using NewBank.Tables.Abstractions;
using NewBank.UI;
using System;
using System.Collections.Generic;

namespace NewBank.Tables.Implementations
{
    public class StatementOfAccount : IStatementOfAccount
    {
        public IAccount Account { get; set; }
        public List<ITransaction> AccountTransactions { get; set; }
        public bool Generator(DIContainer dIContainer, ICustomer customer)
        {
            Account = dIContainer.AccountRepo.ChooseAccount(dIContainer, customer.Email);

            if (Account == null)
            {
                Console.WriteLine("Account not found. Create account");
                HomePage.Display(dIContainer, customer);
                return false;
            }

            //AccountTransactions = dIContainer.TransactionRepo.GetAll(Account.AccountNumber);
            Draw(Account, Account.TransactionHolder);

            return true;
        }

        public void Draw(IAccount account, List<ITransaction> transactions)
        {
            Console.WriteLine($"STATEMENT OF ACCOUNT FOR ACCOUNT NUMBER {account.AccountNumber}");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", "DATE", "DESCRIPTION", "AMOUNT", "BALANCE");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            foreach (var transaction in transactions)
            {
                Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", transaction.Date, transaction.Description, transaction.Amount.ToString(), transaction.AccountBalance.ToString());
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
        }
    }
}
