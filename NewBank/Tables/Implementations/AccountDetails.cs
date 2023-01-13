using NewBank.Models.Abstractions;
using NewBank.Repositories;
using NewBank.Repositories.Abstractions;
using NewBank.Repositories.Implementations;
using NewBank.Tables.Abstractions;
using NewBank.UI;
using System;
using System.Collections.Generic;

namespace NewBank.Tables.Implementations
{
    public class AccountDetails : IAccountDetails
    {
        public List<IAccount> CustomerAccounts { get; set; }
        public bool Generator(DIContainer dIContainer, ICustomer customer)
        {

            CustomerAccounts = dIContainer.AccountRepo.GetAll(customer.Email);
            if (CustomerAccounts.Count < 1)
            {
                Console.WriteLine("Account(s) not found. Please create one.");
                HomePage.Display(dIContainer, customer);
                return false;
            }
            Draw(customer, CustomerAccounts);
            return true;
        }

        public void Draw (ICustomer customer, List<IAccount> accounts)
        {
            Console.WriteLine("ACCOUNT DETAILS");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", "FULL NAME", "ACCOUNT NUMBER", "ACCOUNT TYPE", "AMOUNT BALANCE");
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            foreach (var account in accounts)
            {
                Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", customer.FullName, account.AccountNumber, account.AccountType.ToString(), account.Balance.ToString());
            }
        }
    }
}