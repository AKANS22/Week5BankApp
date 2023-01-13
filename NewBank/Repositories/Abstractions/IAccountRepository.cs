using NewBank.Models.Abstractions;
using System.Collections.Generic;

namespace NewBank.Repositories.Abstractions
{
    public interface IAccountRepository
    {
        public int Choice { get; set; }

        List<IAccount> GetAllAccounts();
        bool Save(string email, IAccount account);
        List<IAccount> GetAll(string email);
        IAccount ChooseAccount(DIContainer dIContainer, string email);
        bool UpdateAccount(string accountNo, IAccount account);
    }
}