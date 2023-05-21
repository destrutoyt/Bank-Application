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
using System.Xml.Linq;
using System.Reflection;

namespace Bank_Application
{
    public class UserAccount
    {
        string user = "";
        string password = "";
        string name = "";
        public bool taxReducer = false;
        public bool storeDiscount = false;
        private int account_number = 0;

        public UserAccount(string user, string password, string name, int account_number) //CONSTRUCTOR
        {
            this.user = user;
            this.password = password;
            this.name = name;
            AccountNumber = account_number;
        }
        public void Details() // REMOVE?
        {
            WriteLine("= = = = = = = = = = = = =");
            WriteLine("PROFILE DETAILS");
            WriteLine($"User: {user}");
            WriteLine($"Name: {name}");
            WriteLine($"Account Number: #{account_number}");
            WriteLine("= = = = = = = = = = = = =");
        }

        public void PremiumPerks(BankAccount bankData, decimal price, string upgradeName, string transactionInfo)
        {
            if (upgradeName == "STORE")
            {
                WriteLine("Starting upgrade transaction....");

                bankData.Balance -= 500;
                bankData.TransactionAmount.Add(price);
                bankData.TransactionName.Add(transactionInfo);
                storeDiscount = true;
                Thread.Sleep(3000);
                Clear();
                WriteLine("CONGRATULATIONS ON YOUR NEW PERK!");
                WriteLine("You can now enjoy 25% off for all purchases!");
                WriteLine("Press ANY key to continue");
                ReadKey();
                Clear();
            }
            else
            {
                WriteLine("Starting upgrade transaction....");

                bankData.Balance -= 300;
                bankData.TransactionAmount.Add(price);
                bankData.TransactionName.Add(transactionInfo);
                taxReducer = true;
                Thread.Sleep(3000);
                Clear();
                WriteLine("CONGRATULATIONS ON YOUR NEW PERK!");
                WriteLine("You can now get 2% off your sales tax for all purchases!");
                WriteLine("Press ANY key to continue");
                ReadKey();
                Clear();
            }
        }
        public void AccountInformation(BankAccount balance)
        {
            WriteLine("= = = = = = = = = = = = =");
            WriteLine("ACCOUNT INFORMATION");
            WriteLine($"Account's Owner: {name}");
            WriteLine($"Balance: {balance.Balance:C}");
            WriteLine($"Wallet: {balance.Wallet:C}");
            WriteLine($"Account Number: #{account_number}");
            WriteLine("");
            WriteLine("= PREMIUM PERKS =");
            if (taxReducer == true)
            {
                WriteLine("Tax Reducer = ACTIVATED");
            }
            else
            {
                WriteLine("Tax Reducer = NOT ACTIVATED");
                if (storeDiscount == true)
                {
                    WriteLine("Store Discount = ACTIVATED");
                }
                else
                {
                    WriteLine("Store Discount = NOT ACTIVATED");
                }
            }
            WriteLine("= = = = = = = = = = = = =");

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