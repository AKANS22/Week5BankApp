using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewBank.Models.Abstractions;
using NewBank.Models.Enum;
using NewBank.Models.Implementations;
using NewBank.Repositories;
using NewBank.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBank.Services.Implementations.Tests
{
    [TestClass()]
    public class CustomerServicesTests
    {
        [TestMethod()]
        public void CreateCustomerTest()
        {
            DIContainer dIContainer = new DIContainer();
            dIContainer.CustomerServ.FirstName = "Zara";
            dIContainer.CustomerServ.LastName = "Emma";
            dIContainer.CustomerServ.Email = "zara@em.com";
            dIContainer.CustomerServ.Password = "Qwe12@";
            var actual = dIContainer.CustomerServ.CreateCustomer(dIContainer);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void CreateAccountTest()
        {
            DIContainer dIContainer = new DIContainer();
            dIContainer.CustomerServ.AccountNumber = "0098722341";
            dIContainer.CustomerServ.AccountType = AccountTypes.Current;
            dIContainer.CustomerServ.AccountEmail = "zara@em.com";
            ICustomer customer = new Customer("Shogo", "Bunmi", "sho@bu.com", "Qwe12@");
            var actual = dIContainer.CustomerServ.CreateAccount(dIContainer, customer);
            Assert.AreEqual(true, actual);
        }
    }
}