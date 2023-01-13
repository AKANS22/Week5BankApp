namespace NewBank.Utilities
{
    public interface IValidations
    {
        bool ValidateAmount(string amount);
        bool ValidateEmail(string email);
        bool ValidateName(string name);
        bool ValidateOption(string option, int choices);
        bool ValidatePassword(string password);
    }
}