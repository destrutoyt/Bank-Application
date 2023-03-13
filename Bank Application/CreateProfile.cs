using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Bank_Application
{
    public class CreateAccount //MUST FINISH BEFORE CONTINUING WITH ANOTHER CLASS (PARTIAL COMPLETION)
    {
        public string user = "";
        public string password = "";
        public string name = "";
        public int account_number = 0;

        public CreateAccount(string user, string password, string name, int account_number) //CONSTRUCTOR
        {
            this.user = user;
            this.password = password;
            this.name = name;
            this.account_number = account_number;
        }
        public void Details() //MUST BE DEVELOP
        {
            WriteLine("= = = = = = = = = = = = =");
            Console.WriteLine("PROFILE DETAILS");
            Console.WriteLine($"User: {user}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Account Number: {account_number}");
            WriteLine("= = = = = = = = = = = = =");
        }

        public void AccountInformation(BankAccount balance)
        {
            WriteLine("= = = = = = = = = = = = =");
            Console.WriteLine("ACCOUNT INFORMATION");
            Console.WriteLine($"Account's Owner: {name}");
            Console.WriteLine($"Balance: {balance.Balance:C}");
            Console.WriteLine($"Account Number: #{this.account_number}");
            WriteLine("= = = = = = = = = = = = =");
        }
    }
}
