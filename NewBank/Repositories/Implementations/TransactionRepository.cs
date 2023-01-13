using NewBank.Models.Abstractions;
using NewBank.Models.Implementations;
using NewBank.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBank.Repositories.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        //public static List<ITransaction> TransactionHolder { get; set; } = new List<ITransaction>();

        public bool Save(ITransaction transaction, IAccount account)
        {
            bool saved = true;
            if (transaction == null)
            {
                saved = false;
            }
            else
            {
                account.TransactionHolder.Add(transaction);
            }
            return saved;
        }

    }
}
