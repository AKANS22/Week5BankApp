using System;
using System.Collections.Generic;
using System.Text;

namespace NewBank.Utilities
{
    public static class StandardMessages
    {
        public static string InvalidOption()
        {
            return ("\nInvalid input. Please select a valid option");
        }

        public static string NameError()
        {
            return ("\nInvalid name format. Try again.");
        }

        public static string EmailError()
        {
            return ("\nInvalid email format. Try again.");
        }

        public static string PasswordError()
        {
            return ("\nPassword not strong enough. Try again");
        }

        public static string InvalidAmount()
        {
            return "\nInvalid amount. Please enter a valid amount.";
        }
    }
}
