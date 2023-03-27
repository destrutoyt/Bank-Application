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
        public int account_number = 0;

        public Account(string user, string password, string name, int account_number) //CONSTRUCTOR
        {
            this.user = user;
            this.password = password;
            this.name = name;
            this.account_number = account_number;
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
            WriteLine("= = = = = = = = = = = = =");
            WriteLine("ACCOUNT INFORMATION");
            WriteLine($"Account's Owner: {name}");
            WriteLine($"Balance: {balance.Balance:C}");
            WriteLine($"Account Number: #{this.account_number}");
            WriteLine("= = = = = = = = = = = = =");
        }

        public string User { get { return user; } }
    }
}