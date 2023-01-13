using NewBank.Models.Abstractions;
using NewBank.Repositories;
using NewBank.Utilities;
using System;

namespace NewBank.UI
{
    public static class HomePage
    {
        public static void Display(DIContainer dIContainer, ICustomer customer)
        {
            Console.WriteLine($"WELCOME {customer.FirstName}.\n\n");
            Console.WriteLine("Please select an operation...");
            Console.WriteLine("\n1 - Open Another Account\n2 - Deposit\n3 - Withdraw\n4 - Transfer\n5 - Get Account Details\n6 - Get Statement of Account\n7 - Log Out");
            Console.Write("\nEnter input here: ");
            string option = Console.ReadLine();

            while (dIContainer.Validate.ValidateOption(option, 7) == false)
            {
                Console.WriteLine(StandardMessages.InvalidOption());
                option = Console.ReadLine();
            }

            if (option == "1")
            {
                Console.Clear();
                dIContainer.CustomerServ.CreateAccount(dIContainer, customer);
            }
            else if (option == "2")
            {
                Console.Clear();
                dIContainer.AccountService.Deposit(dIContainer, customer, customer.Email);
            }
            else if (option == "3")
            {
                Console.Clear();
                dIContainer.AccountService.Withdraw(dIContainer, customer, customer.Email);
            }
            else if (option == "4")
            {
                Console.Clear();
                dIContainer.AccountService.Transfer(dIContainer, customer, customer.Email);
            }
            else if (option == "5")
            {
                Console.Clear();
                dIContainer.AccountDets.Generator(dIContainer, customer);
            }
            else if (option == "6")
            {
                Console.Clear();
                dIContainer.SOA.Generator(dIContainer, customer);
            }
            Console.Clear();
            WelcomePage.Welcome(dIContainer);
        }
    }
}
