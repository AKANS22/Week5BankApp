using NewBank.Repositories.Abstractions;
using NewBank.Repositories.Implementations;
using NewBank.Services.Abstractions;
using NewBank.Services.Implementations;
using NewBank.Tables.Abstractions;
using NewBank.Tables.Implementations;
using NewBank.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBank.Repositories
{
    public class DIContainer
    {
        public IAccountRepository AccountRepo { get; set; } = new AccountRepository();
        public ICustomerRepository CustomerRepo { get; set; } = new CustomerRepository();
        public ITransactionRepository TransactionRepo { get; set; } = new TransactionRepository();
        public IAccountServices AccountService { get; set; } = new AccountServices();
        public ICustomerServices CustomerServ { get; set; } = new CustomerServices();
        public IValidations Validate { get; set; } = new Validations();
        public IAccountDetails AccountDets { get; set; } = new AccountDetails();
        public IStatementOfAccount SOA { get; set; } = new StatementOfAccount();
    }
}
