using System;
using System.Threading;
using NewBank.Models.Abstractions;
using NewBank.Models.Enum;
using NewBank.Models.Implementations;
using NewBank.Services.Abstractions;
using NewBank.Utilities;
using NewBank.UI;
using NewBank.Repositories;
using System.Collections.Generic;

namespace NewBank.Services.Implementations
{
    public class CustomerServices : ICustomerServices
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountNumber { get; set; }
        public string AccountEmail { get; set; }
        public AccountTypes AccountType { get; set; }
        public decimal Balance { get; set; }
        public List<ITransaction> TransactionHolder { get; set; }

        public bool CreateCustomer(DIContainer dIContainer)
        {
            bool created = false;
            //For unit test
            if (FirstName != null || LastName != null || Email != null || Password != null)
            {
                if (dIContainer.Validate.ValidateName(FirstName)! && dIContainer.Validate.ValidateName(LastName) && dIContainer.Validate.ValidateEmail(Email) && dIContainer.Validate.ValidatePassword(Password))
                {
                    ICustomer testCustomer = new Customer(FirstName, LastName, Email, Password);
                    created = true;
                }
                return created;
            }
            //
            try
            {
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine().Trim().ToUpper();
                while (dIContainer.Validate.ValidateName(firstName) == false)
                {
                    Console.WriteLine(StandardMessages.NameError()); 
                    firstName = Console.ReadLine();
                }
                FirstName = firstName;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            
            try
            {
                Console.Write("\nEnter Last Name: ");
                string lastName = Console.ReadLine().Trim().ToUpper();
                while (dIContainer.Validate.ValidateName(lastName) == false)
                {
                    Console.WriteLine(StandardMessages.NameError());
                    lastName = Console.ReadLine();
                }
                LastName = lastName;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }            

            try
            {
                Console.Write("\nEnter Email (e.g. johndoe@gmail.com): ");
                string email = Console.ReadLine().Trim().ToLower();
                while (dIContainer.Validate.ValidateEmail(email) == false)
                {
                    Console.WriteLine(StandardMessages.EmailError());
                    email = Console.ReadLine();
                }
                Email = email;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            
            try
            {
                Console.Write("\nEnter Password (Must be alphanumerics and contain at least one\nspecial character (e.g. @, #, $, ^, &, !): ");
                string password = Console.ReadLine();
                while (dIContainer.Validate.ValidatePassword(password) == false)
                {
                    Console.WriteLine(StandardMessages.PasswordError());
                    password = Console.ReadLine();
                }
                Password = password;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            
            ICustomer customer = new Customer(FirstName, LastName, Email, Password);
            try
            {
                if (dIContainer.CustomerRepo.Save(customer) == false)
                {
                    Console.WriteLine("\nAccount already exists");
                    Thread.Sleep(2000);
                    WelcomePage.Welcome(dIContainer);
                    return created;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            
            dIContainer.CustomerRepo.Save(customer);

            Console.Clear();
            CreateAccount(dIContainer, customer);
            created = true;
            return created;
        }
        
        public bool CreateAccount(DIContainer dIContainer, ICustomer customer)
        {
            bool created = false;
            //For unit test
            if (AccountNumber != null || AccountEmail != null || AccountType != 0)
            {
                if (dIContainer.Validate.ValidateEmail(AccountEmail))
                {
                    IAccount testAccount = new Account(AccountNumber, AccountEmail, AccountType, Balance);
                    created = true;
                }
                return created;
            }
            //
            try
            {
                //IAccount account = new Account();
                Console.WriteLine("Choose Account Type\n\n1 - Savings\n\t2 - Current");
                Console.Write("\nEnter input here: ");
                string option = Console.ReadLine();
                while (dIContainer.Validate.ValidateOption(option, 2) == false)
                {
                    Console.WriteLine(StandardMessages.InvalidOption());
                    option = Console.ReadLine();
                }
                if (option == "1")
                {
                    AccountType = AccountTypes.Savings;
                }
                if (option == "2")
                {
                    AccountType = AccountTypes.Current;
                }
            }
            catch(Exception e) { Console.WriteLine(e.Message); }

            AccountNumber = AccountNumberGenerator.GenerateAccountNumber();
            AccountEmail = customer.Email;

            IAccount account = new Account(AccountNumber, AccountEmail, AccountType, Balance);
            dIContainer.AccountRepo.Save(account.AccountEmail, account);

            try
            {
                if (dIContainer.AccountRepo.Save(account.AccountEmail, account) == false)
                {
                    Console.WriteLine("\nAccount creation failed");
                    Thread.Sleep(2000);
                    Console.Clear();
                    HomePage.Display(dIContainer, customer);
                    return created;
                }

                Console.Clear();
                Console.WriteLine("\nAccount creation successful");
                Thread.Sleep(2000);
                Console.Clear();
                HomePage.Display(dIContainer, customer);
                created = true;
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
            return created;
        }

        public bool Login(DIContainer dIContainer)
        {
            bool loggedIn = false;
            try
            {
                Console.Write("\nEnter email: ");
                string email = Console.ReadLine();
                Console.Write("\nEnter password: ");
                string password = Console.ReadLine();

                ICustomer customer = dIContainer.CustomerRepo.Get(email, password);
                if (customer == null)
                {
                    Console.WriteLine("\nAccount does not exist. Try login again or Create new account");
                    Thread.Sleep(2000);
                    Console.Clear();
                    WelcomePage.Welcome(dIContainer);
                    return loggedIn;
                }

                Console.WriteLine("\nLogin successful");
                Thread.Sleep(2000);
                Console.Clear();
                HomePage.Display(dIContainer, customer);
                loggedIn = true;
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
            return loggedIn;
        }
    }
}
