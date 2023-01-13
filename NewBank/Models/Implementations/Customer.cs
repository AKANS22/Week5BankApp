using System;
using System.Collections.Generic;
using System.Text;
using NewBank.Models.Abstractions;

namespace NewBank.Models.Implementations
{
    public class Customer : ICustomer
    {
        public Customer(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public Customer()
        {
                
        }

        public Customer(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        //public static readonly List<ICustomer> OurCustomers = new List<Customer>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public readonly List<IAccount> CustomerAccounts = new List<Account>();
    }
}
