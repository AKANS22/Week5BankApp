using System;
using NewBank.Repositories;
using NewBank.Utilities;

namespace NewBank.UI
{
    public static class WelcomePage
    {
        public static void Welcome(DIContainer dIContainer)
        {
            
            Console.WriteLine("Please select an operation...");
            Console.WriteLine("\n1: Login\n\t2: Open Account\n\t\t3: Exit App");
            Console.Write("\nEnter input here: ");
            string option = Console.ReadLine();

            while (dIContainer.Validate.ValidateOption(option, 3) == false)
            {
                Console.WriteLine(StandardMessages.InvalidOption());
                option = Console.ReadLine();
            }
            //Option = option;

            if (option == "1")
            {
                Console.Clear();
                dIContainer.CustomerServ.Login(dIContainer);
            }
            else if (option == "2")
            {
                Console.Clear();
                dIContainer.CustomerServ.CreateCustomer(dIContainer);
            }
            else
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }
    }
}
