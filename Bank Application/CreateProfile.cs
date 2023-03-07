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
        public string user;
        public string password;
        public string name;
        public double balance;
        public int account_number;

        public CreateAccount(string user, string password, string name, double balance, int account_number) //CONSTRUCTOR
        {
            this.user = user;
            this.password = password;
            this.name = name;
            this.balance = balance;
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
        public void deposit(double amount)
        {
            balance += amount;
        }
    }
}
