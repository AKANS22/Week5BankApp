using NewBank.Models.Abstractions;
using NewBank.Models.Enum;
using NewBank.Models.Implementations;
using NewBank.Repositories;
using NewBank.Services.Abstractions;
using NewBank.UI;
using NewBank.Utilities;
using System;
using System.Threading;

namespace NewBank.Services.Implementations
{
    public class AccountServices : IAccountServices
    {
        public string Amount { get; set; }
        public IAccount Account { get; set; }
        public IAccount OtherAccount { get; set; }

        public string CheckBalance(DIContainer dIContainer, ICustomer customer, string email)
        {
            //For unit test.
            if (Account != null)
            {
                return $"Your account balace is #{Account.Balance}.";
            }
            //
            try
            {
                Account = dIContainer.AccountRepo.ChooseAccount(dIContainer, email);
                Console.WriteLine($"Your account balace is #{Account.Balance}.");
                Thread.Sleep(2000);
                Console.Clear();
                HomePage.Display(dIContainer, customer);
                return "";
            }
            catch (Exception ex) { return $"{ex.Message}"; }
        }

        public bool Deposit(DIContainer dIContainer, ICustomer customer, string email)
        {
            bool credited = false;
            //For unit test.
            if (Account != null && Amount != null)
            {
                if (dIContainer.Validate.ValidateAmount(Amount))
                {
                    Account.Balance += decimal.Parse(Amount);
                    credited = true;
                }
                return credited;
            }
            //
            try
            {
                Console.Write("Enter the amount to deposit: ");
                Amount = Console.ReadLine();

                while (dIContainer.Validate.ValidateAmount(Amount) == false)
                {
                    Console.WriteLine(StandardMessages.InvalidAmount());
                    Amount = Console.ReadLine();
                }

                Console.WriteLine("\nPlease select account for deposit");
                Account = dIContainer.AccountRepo.ChooseAccount(dIContainer, email);
                if (Account == null)
                {
                    Console.WriteLine("Account(s) not found. Please create one.");
                    HomePage.Display(dIContainer, customer);
                    return credited;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); };
            
            Account.Balance += decimal.Parse(Amount);

            ITransaction transaction = new Transaction(Account.AccountNumber, "Credited", Amount, Account.Balance, DateTime.Now.ToShortTimeString());
            dIContainer.TransactionRepo.Save(transaction, Account);
            dIContainer.AccountRepo.UpdateAccount(Account.AccountNumber, Account);

            Console.Clear();
            Console.WriteLine("Deposit successful.");
            Thread.Sleep(2000);
            Console.Clear();
            HomePage.Display(dIContainer, customer);
            credited = true;
            return credited;
        }

        public bool Withdraw(DIContainer dIContainer, ICustomer customer, string email)
        {
            bool debited = false;
            //For unit test.
            if (Account != null && Amount != null)
            {
                if (dIContainer.Validate.ValidateAmount(Amount))
                {
                    if ((Account.AccountType.ToString() == "Savings" && (Account.Balance < 1000 || Account.Balance - decimal.Parse(Amount) < 1000)) || Account.Balance - decimal.Parse(Amount) < 0)
                    {
                        Console.WriteLine("Insufficient funds");
                        return debited;
                    }
                    Account.Balance -= decimal.Parse(Amount);
                    debited = true;
                }
                return debited;
            }
            //
            try
            {
                Console.Write("Enter the amount to withdraw: ");
                while (dIContainer.Validate.ValidateAmount(Amount))
                {
                    Console.WriteLine(StandardMessages.InvalidAmount());
                    Amount = Console.ReadLine();
                }

                Console.WriteLine("\nPlease select account for withdrawal");
                Account = dIContainer.AccountRepo.ChooseAccount(dIContainer, email);
                if (Account == null)
                {
                    Console.WriteLine("Account(s) not found. Please create one.");
                    HomePage.Display(dIContainer, customer);
                    return debited;
                }

                if ((Account.AccountType.ToString() == "Savings" && Account.Balance < 1000) || Account.Balance - decimal.Parse(Amount) < 0)
                {
                    Console.WriteLine("Insufficient funds");
                    Thread.Sleep(2000);
                    HomePage.Display(dIContainer, customer);
                    return debited;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Account.Balance -= decimal.Parse(Amount);

            ITransaction transaction = new Transaction(Account.AccountNumber, "Debited", Amount, Account.Balance, DateTime.Now.ToShortTimeString());
            dIContainer.TransactionRepo.Save(transaction, Account);
            dIContainer.AccountRepo.UpdateAccount(Account.AccountNumber, Account);

            Console.Clear();
            Console.WriteLine("Withdrawal successful.");
            Thread.Sleep(2000);
            Console.Clear();
            HomePage.Display(dIContainer, customer);
            return true;
        }

        public bool Transfer(DIContainer dIContainer, ICustomer customer, string email)
        {
            bool debited = false;
            //For unit test.
            if (Account != null && OtherAccount != null && Amount != null)
            {
                if (dIContainer.Validate.ValidateAmount(Amount))
                {
                    if ((Account.AccountType.ToString() == "Savings" && (Account.Balance < 1000 || Account.Balance - decimal.Parse(Amount) < 1000)) || Account.Balance - decimal.Parse(Amount) < 0)
                    {
                        Console.WriteLine("Insufficient funds");
                        return debited;
                    }
                    Account.Balance -= decimal.Parse(Amount);
                    OtherAccount.Balance += decimal.Parse(Amount);
                    debited = true;
                }
                return debited;
            }
            //
            try
            {
                Console.Write("Enter the amount to transfer: ");
                Amount = Console.ReadLine();

                while (dIContainer.Validate.ValidateAmount(Amount))
                {
                    Console.WriteLine(StandardMessages.InvalidAmount());
                    Amount = Console.ReadLine();
                }

                Console.WriteLine("\nPlease select sender account");
                Account = dIContainer.AccountRepo.ChooseAccount(dIContainer, email);
                if (Account == null)
                {
                    Console.WriteLine("Accounts not found. Please create one.");
                    Thread.Sleep(2000);
                    HomePage.Display(dIContainer, customer);
                    return false;
                }

                Console.WriteLine("\nPlease select receiver account");
                OtherAccount = dIContainer.AccountRepo.ChooseAccount(dIContainer, email);
                if (OtherAccount == null)
                {
                    Console.WriteLine("Accounts not found. Please create one.");
                    Thread.Sleep(2000);
                    HomePage.Display(dIContainer, customer);
                    return false;
                }

                if (OtherAccount.AccountNumber == Account.AccountNumber)
                {
                    Console.WriteLine("Transfer failed. Cannot send to same account.");
                    Thread.Sleep(2000);
                    HomePage.Display(dIContainer, customer);
                    return false;
                }

                if ((Account.AccountType.ToString() == "Savings" && (Account.Balance < 1000 || Account.Balance - decimal.Parse(Amount) < 1000)) || Account.Balance - decimal.Parse(Amount) < 0)
                {
                    Console.WriteLine("Insufficient funds");
                    Thread.Sleep(2000);
                    HomePage.Display(dIContainer, customer);
                    return false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
            Account.Balance -= decimal.Parse(Amount);
            OtherAccount.Balance += decimal.Parse(Amount);
            ITransaction transaction = new Transaction(Account.AccountNumber, "Debited", Amount, Account.Balance, DateTime.Now.ToShortTimeString());
            ITransaction transaction1 = new Transaction(OtherAccount.AccountNumber, "Credited", Amount, Account.Balance, DateTime.Now.ToShortTimeString());
            dIContainer.TransactionRepo.Save(transaction, Account);
            dIContainer.TransactionRepo.Save(transaction1, Account);
            dIContainer.AccountRepo.UpdateAccount(Account.AccountNumber, Account);
            dIContainer.AccountRepo.UpdateAccount(OtherAccount.AccountNumber, Account);

            Console.Clear();
            Console.WriteLine("Transfer successful.");
            Thread.Sleep(2000);
            Console.Clear();
            HomePage.Display(dIContainer, customer);
            return true;
        }
    }
}
