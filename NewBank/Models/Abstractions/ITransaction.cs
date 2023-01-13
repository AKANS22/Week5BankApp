using System;
using System.Collections.Generic;
using System.Text;

namespace NewBank.Models.Abstractions
{
    public interface ITransaction
    {
        string AccountNumber { get; set; }
        string Description { get; set; }
        string Date { get; set; }
        string Amount { get; set; }
        decimal AccountBalance { get; set; }
    }
}
