using NewBank.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewBank.Models.Abstractions;
using NewBank.Models.Implementations;
using NewBank.Repositories;

namespace NewBank.Services.Implementations.Tests
{
    [TestClass()]
    public class AccountServicesTests
    {
        [TestMethod()]
        public void CheckBalanceTest()
        {
            DIContainer dIContainer = new DIContainer();
            dIContainer.AccountService.Account = new Account("", "", Models.Enum.AccountTypes.Savings, 1000);
            ICustomer customer = new Customer("", "");
            string expected = "Your account balace is #1000.";
            string actual = dIContainer.AccountService.CheckBalance(dIContainer, customer, customer.Email);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DepositTest1()
        {
            DIContainer dIContainer = new DIContainer();
            dIContainer.AccountService.Account = new Account("", "", Models.Enum.AccountTypes.Savings, 1000);
            dIContainer.AccountService.Amount = "1000";
            ICustomer customer = new Customer("", "");
            decimal expected = 2000;
            var result = dIContainer.AccountService.Deposit(dIContainer, customer, customer.Email);
            decimal actual = dIContainer.AccountService.Account.Balance;
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DepositTest2()
        {
            DIContainer dIContainer = new DIContainer();
            dIContainer.AccountService.Account = new Account("", "", Models.Enum.AccountTypes.Savings, 1000);
            dIContainer.AccountService.Amount = "-1000";
            ICustomer customer = new Customer("", "");
            decimal expected = 1000;
            var result = dIContainer.AccountService.Deposit(dIContainer, customer, customer.Email);
            decimal actual = dIContainer.AccountService.Account.Balance;
            Assert.AreEqual(expected, actual);
            Assert.IsFalse(result);

        }

        [TestMethod()]
        public void WithdrawTest1()
        {
            DIContainer dIContainer = new DIContainer();
            dIContainer.AccountService.Account = new Account("", "", Models.Enum.AccountTypes.Savings, 3000);
            dIContainer.AccountService.Amount = "1000";
            ICustomer customer = new Customer("", "");
            decimal expected = 2000;
            var result = dIContainer.AccountService.Withdraw(dIContainer, customer, customer.Email);
            decimal actual = dIContainer.AccountService.Account.Balance;
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void WithdrawTest2()
        {
            DIContainer dIContainer = new DIContainer();
            dIContainer.AccountService.Account = new Account("", "", Models.Enum.AccountTypes.Savings, 1500);
            dIContainer.AccountService.Amount = "1000";
            ICustomer customer = new Customer("", "");
            decimal expected = 1500;
            var result = dIContainer.AccountService.Withdraw(dIContainer, customer, customer.Email);
            decimal actual = dIContainer.AccountService.Account.Balance;
            Assert.AreEqual(expected, actual);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void WithdrawTest3()
        {
            DIContainer dIContainer = new DIContainer();
            dIContainer.AccountService.Account = new Account("", "", Models.Enum.AccountTypes.Current, 1500);
            dIContainer.AccountService.Amount = "1000";
            ICustomer customer = new Customer("", "");
            decimal expected = 500;
            var result = dIContainer.AccountService.Withdraw(dIContainer, customer, customer.Email);
            decimal actual = dIContainer.AccountService.Account.Balance;
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Transfer_Test_Return_Equal()
        {
            DIContainer dIContainer = new DIContainer();
            dIContainer.AccountService.Account = new Account("", "", Models.Enum.AccountTypes.Savings, 3000);
            dIContainer.AccountService.OtherAccount = new Account("", "", Models.Enum.AccountTypes.Savings, 3000);
            dIContainer.AccountService.Amount = "1000";
            ICustomer customer = new Customer("", "");
            decimal expected1 = 2000;
            decimal expected2 = 4000;
            var result = dIContainer.AccountService.Transfer(dIContainer, customer, customer.Email);
            decimal actual1 = dIContainer.AccountService.Account.Balance;
            decimal actual2 = dIContainer.AccountService.OtherAccount.Balance;
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.IsTrue(result);
        }
    }
}