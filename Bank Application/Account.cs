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
    public class Account
    {
        string user = "";
        string password = "";
        string name = "";
        public bool taxReducer = false;
        public bool storeDiscount = false;
        private int account_number = 0;

        public Account(string user, string password, string name, int account_number) //CONSTRUCTOR
        {
            this.user = user;
            this.password = password;
            this.name = name;
            AccountNumber = account_number;
        }
        public void Details()
        {
            WriteLine("= = = = = = = = = = = = =");
            WriteLine("PROFILE DETAILS");
            WriteLine($"User: {user}");
            WriteLine($"Name: {name}");
            WriteLine($"Account Number: {account_number}");
            WriteLine("= = = = = = = = = = = = =");
        }

        public void ProfileUpgrades(BankAccount bankData, decimal price, string upgradeName, string transactionType)
        {
            if (upgradeName == "STORE")
            {
                WriteLine("Starting upgrade transaction....");

                bankData.Balance -= 250;
                bankData.transactionAmount.Add(price);
                bankData.transactionType.Add(transactionType);
                storeDiscount = true;
                Thread.Sleep(3000);
                Clear();
                WriteLine("CONGRATULATIONS ON YOUR NEW UPGRADE!");
                WriteLine("You can now enjoy 25% off for all purchases!");
                WriteLine("Press ANY key to continue");
                ReadKey();
                Clear();
            }
            else
            {
                WriteLine("Starting upgrade transaction....");

                bankData.Balance -= 250;
                bankData.transactionAmount.Add(price);
                bankData.transactionType.Add(transactionType);
                taxReducer = true;
                Thread.Sleep(3000);
                Clear();
                WriteLine("CONGRATULATIONS ON YOUR NEW UPGRADE!");
                WriteLine("You can now get 2.25% off your sales tax for all purchases!");
                WriteLine("Press ANY key to continue");
                ReadKey();
                Clear();
            }
        }

        public void AccountInformation(BankAccount balance)
        {
            if (balance.Balance < -1)
            {
                WriteLine("= = = = = = = = = = = = =");
                WriteLine("ACCOUNT INFORMATION");
                WriteLine($"Account's Owner: {name}");
                WriteLine($"Balance: -{balance.Balance:C}");
                WriteLine($"Wallet: {balance.Wallet:C}");
                WriteLine($"Account Number: #{this.account_number}");
                WriteLine("");
                WriteLine("OWNED PURCHASES");
                if (taxReducer == true)
                {
                    WriteLine("Tax Reducer = ACTIVATED");
                }
                if (storeDiscount == true)
                {
                    WriteLine("Store Discount = ACTIVATED");
                }   
                else
                {
                    WriteLine("none");
                }
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
                WriteLine("");
                WriteLine("OWNED PURCHASES");
                if (taxReducer == true)
                {
                    WriteLine("Tax Reducer = ACTIVATED");
                }
                if (storeDiscount == true)
                {
                    WriteLine("Store Discount = ACTIVATED");
                }
                else
                {
                    WriteLine("none");
                }
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