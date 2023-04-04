using System;
using System.Collections.Generic;
using System;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Bank_Application
{
    public class Account //MUST FINISH BEFORE CONTINUING WITH ANOTHER CLASS (PARTIAL COMPLETION)
    {
        public string user = "";
        public string password = "";
        public string name = "";
        private int account_number = 0;

        public Account(string user, string password, string name, int account_number) //CONSTRUCTOR
        {
            this.user = user;
            this.password = password;
            this.name = name;
            AccountNumber = account_number;
        }
        public void Details() //MUST BE DEVELOP
        {
            WriteLine("= = = = = = = = = = = = =");
            WriteLine("PROFILE DETAILS");
            WriteLine($"User: {user}");
            WriteLine($"Name: {name}");
            WriteLine($"Account Number: {account_number}");
            WriteLine("= = = = = = = = = = = = =");
        }

        public void AccountInformation(BankAccount balance)
        {
            if (balance.Balance < 0)
            {
                WriteLine("= = = = = = = = = = = = =");
                WriteLine("ACCOUNT INFORMATION");
                WriteLine($"Account's Owner: {name}");
                WriteLine($"Balance: {balance.Balance:C} YOU HAVE A NEGATIVE BALANCE!");
                WriteLine($"Wallet: {balance.Wallet:C}");
                WriteLine($"Account Number: #{this.account_number}");
                WriteLine("= = = = = = = = = = = = =");
            }
            else
            {
                WriteLine("= = = = = = = = = = = = =");
                WriteLine("ACCOUNT INFORMATION");
                WriteLine($"Account's Owner: {name}");
                WriteLine($"Balance: {balance.Balance:C}");
                WriteLine($"Wallet: {balance.Wallet:C}");
                WriteLine($"Account Number: #{this.account_number}");
                WriteLine("= = = = = = = = = = = = =");
            }
        }
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int AccountNumber
        {
            get { return account_number; }
            set { account_number = value; }
        }
    }
}