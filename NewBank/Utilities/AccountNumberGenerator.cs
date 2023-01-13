using System;
using System.Collections.Generic;
using System.Text;

namespace NewBank.Utilities
{
    public static class AccountNumberGenerator
    {
        public static string GenerateAccountNumber()
        {
            StringBuilder accountNumber = new StringBuilder("0", 10);
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                accountNumber.Append(random.Next(0, 9));
            }
            return accountNumber.ToString();
        }
    }
}
