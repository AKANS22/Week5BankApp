using System;
using System.Collections.Generic;
using System.Text;

namespace NewBank.Models.Abstractions
{
    public interface ICustomer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string FullName => $"{LastName}, {FirstName}";
    }
}
