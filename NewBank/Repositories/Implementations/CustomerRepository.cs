using Microsoft.VisualBasic;
using NewBank.Models.Abstractions;
using NewBank.Models.Implementations;
using NewBank.Repositories.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace NewBank.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<ICustomer> GetAllCustomers()
        {
            List<ICustomer> Customers = new List<ICustomer>();
            var e = File.Exists("customers.json");
            if (e && new FileInfo("customers.json").Length != 0)
            {
                try
                {
                    Customers = JsonConvert.DeserializeObject<List<ICustomer>>(File.ReadAllLines("customers.json")[0], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    return Customers;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Customers;
        }

        public bool Save(ICustomer customer)
        {
            bool saved = true;
            var AllCustomers = GetAllCustomers();
            if (AllCustomers != null)
            {
                foreach (ICustomer c in AllCustomers)
                {
                    if (c.Email == customer.Email)
                    {
                        saved = false;
                        return false;
                    }
                }
            }
            try
            {
                AllCustomers = new List<ICustomer>{ customer };
                //var json = JsonConvert.SerializeObject(GetAllCustomers());
                File.WriteAllText("customers.json", JsonConvert.SerializeObject(AllCustomers, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return saved;
        }

        public ICustomer Get(string email, string password)
        {
            var getAllCustomer = GetAllCustomers();

            ICustomer customer;
            foreach (var cust in getAllCustomer)
            {
                
                if (cust.Email == email)
                {
                    customer = cust;
                    return customer;
                }
            }
            return null;
        }
    }
}
