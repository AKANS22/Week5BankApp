using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewBank.Repositories;
using NewBank.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBank.Utilities.Tests
{
    [TestClass()]
    public class ValidationsTests
    {
        [TestMethod()]
        public void ValidateOptionTest1()
        {
            DIContainer dIContainer = new DIContainer();
            string option = "e";
            int choices = 3;
            var actual = dIContainer.Validate.ValidateOption(option, choices);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void ValidateOptionTest2()
        {
            DIContainer dIContainer = new DIContainer();
            string option = "1";
            int choices = 3;
            var actual = dIContainer.Validate.ValidateOption(option, choices);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void ValidateNameTest1()
        {
            DIContainer dIContainer = new DIContainer();
            string name = "     ";
            var actual = dIContainer.Validate.ValidateName(name);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void ValidateNameTest2()
        {
            DIContainer dIContainer = new DIContainer();
            string name = "dan";
            var actual = dIContainer.Validate.ValidateName(name);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void ValidateEmailTest1()
        {
            DIContainer dIContainer = new DIContainer();
            string email = "zara..@";
            var actual = dIContainer.Validate.ValidateEmail(email);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void ValidateEmailTest2()
        {
            DIContainer dIContainer = new DIContainer();
            string email = "zara@em.co";
            var actual = dIContainer.Validate.ValidateEmail(email);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void ValidatePasswordTest1()
        {
            DIContainer dIContainer = new DIContainer();
            string password = "q1@";
            var actual = dIContainer.Validate.ValidatePassword(password);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void ValidatePasswordTest2()
        {
            DIContainer dIContainer = new DIContainer();
            string password = "q1@";
            var actual = dIContainer.Validate.ValidatePassword(password);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void ValidateAmountTest1()
        {
            DIContainer dIContainer = new DIContainer();
            string amount = "-1000";
            var actual = dIContainer.Validate.ValidateAmount(amount);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void ValidateAmountTest2()
        {
            DIContainer dIContainer = new DIContainer();
            string amount = "1090";
            var actual = dIContainer.Validate.ValidateAmount(amount);
            Assert.AreEqual(true, actual);
        }
    }
}