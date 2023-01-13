using NewBank.Models.Abstractions;
using NewBank.Repositories.Abstractions;
using NewBank.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace NewBank.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        public int Choice { get; set; } = 1;

        public List<IAccount> GetAllAccounts()
        {
            List<IAccount> Accounts = new List<IAccount>();
            if (File.Exists("accounts.json"))
            {
                try
                {
                    var file = new FileInfo("accounts.json");
                    if (file.Length <= 0) return Accounts;
                    var jsonStr = File.ReadAllLines("accounts.json")[0];
                    Accounts = JsonConvert.DeserializeObject<List<IAccount>>(File.ReadAllLines("accounts.json")[0], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Accounts;
        }

        public bool Save(string email, IAccount account)
        {
            bool saved = true;
            var AllAccounts = GetAllAccounts();
            if (AllAccounts != null)
            {
                AllAccounts.Add(account);
            }
            AllAccounts = new List<IAccount> { account };
            //var objToJson = JsonConvert.SerializeObject(GetAllAccounts());
            File.WriteAllText("accounts.json", JsonConvert.SerializeObject(AllAccounts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));
            return saved;
        }
        
        public IAccount ChooseAccount(DIContainer dIContainer, string email)
        {
            var AllAcounts = GetAllAccounts();
            foreach (IAccount acct in AllAcounts)
            {
                if (acct.AccountEmail == email)
                {
                    Console.WriteLine($"\n{Choice} - {acct.AccountNumber}, {acct.AccountType}");
                    Choice++;
                    Console.Write("\nEnter input here: ");
                    string option = Console.ReadLine();

                    while (dIContainer.Validate.ValidateOption(option, Choice) == false)
                    {
                        Console.WriteLine(StandardMessages.InvalidOption());
                        option = Console.ReadLine();
                    }
                    var accounts = GetAll(email);
                    var account = accounts[int.Parse(option) - 1];
                    return account;
                }
            }
            return null;
        }

        public List<IAccount> GetAll(string email)
        {
            var AllAcounts = GetAllAccounts();
            List<IAccount> customersAccounts = new List<IAccount>();
            foreach (IAccount c in AllAcounts)
            {
                if (c.AccountEmail == email)
                {
                    customersAccounts.Add(c);
                }
            }
            return customersAccounts;
        }

        public bool UpdateAccount(string accountNumber, IAccount account)
        {
            var AllAccounts = GetAllAccounts();
            if (AllAccounts.Count > 0)
            {
                try
                {
                    for (int i = 0; i < GetAllAccounts().Count; i++)
                    {
                        if (AllAccounts[i].AccountNumber == accountNumber)
                        {
                            AllAccounts[i] = account;
                            //var objToJson = JsonConvert.SerializeObject(GetAllAccounts());
                            File.WriteAllText("accounts.json", JsonConvert.SerializeObject(AllAccounts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));
                            return true;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return false;
        }
    }
}
