using System;
using NewBank.Models.Abstractions;
using System.Collections.Generic;
using NewBank.Repositories;
using NewBank.UI;
using Newtonsoft.Json;
using System.IO;

namespace NewBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var c = JsonConvert.DeserializeObject<List<ICustomer>>(File.ReadAllLines("customers.json")[0], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            //Console.WriteLine(c.Count);
            Console.WriteLine("\nWelcome to 216 Bank\n\n\n".ToUpper());

            DIContainer dIContainer = new DIContainer();

            WelcomePage.Welcome(dIContainer);

        }
    }
}
