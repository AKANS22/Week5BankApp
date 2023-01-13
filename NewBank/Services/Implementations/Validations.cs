using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NewBank.Utilities
{
    public class Validations : IValidations
    {
        public bool ValidateOption(string option, int choices)
        {
            bool isValid = false;
            if (int.TryParse(option, out _) && int.Parse(option) >= 1 && int.Parse(option) <= choices)
            {
                isValid = true;
            }
            return isValid;
        }

        public bool ValidateName(string name)
        {
            bool isValid = true;
            if (name.Any(char.IsDigit) || !name.Any(char.IsLetter) || name.Any(char.IsWhiteSpace) || name.Length < 2 || string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            return isValid;
        }

        public bool ValidateEmail(string email)
        {
            bool isValid = false;
            if (email.Contains('@') && email.Contains('.') && !email.Any(char.IsWhiteSpace) && email.LastIndexOf(".") > email.LastIndexOf('@') + 1)
            {
                isValid = true;
            }
            return isValid;
        }

        public bool ValidatePassword(string password)
        {
            string pattPassword = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$";
            Regex rg = new Regex(pattPassword);
            return rg.IsMatch(password);
        }

        public bool ValidateAmount(string amount)
        {
            bool isValid = true;
            if (!double.TryParse(amount, out _) || double.Parse(amount) < 1)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
