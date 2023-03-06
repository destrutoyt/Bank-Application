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
        int[] storeC_Id = { }; //STORES ID
        string[] storeUser = { }; //STORES USER
        string[] storePassword = { }; //STORES PASSWORD
        string[] storeCustomer = { }; //STORES CUSTOMER
        double balance;
        int account_number;

        public CreateAccount(int[] storeC_Id, string[] storeUser, string[] storePassword, string[] storeCustomer, double balance, int account_number) //CONSTRUCTOR
        {
            this.storeC_Id = storeC_Id;
            this.storeUser = storeUser;
            this.storePassword = storePassword;
            this.storeCustomer = storeCustomer;
            this.balance = balance;
            this.account_number = account_number;
        }
        public void Details() //MUST BE DEVELOP
        {
            WriteLine("= = = = = = = = = = = = =");
            Console.WriteLine("PROFILE DETAILS");
            Console.WriteLine($"User: {storeUser[0]}");
            Console.WriteLine($"Name: {storeCustomer[0]}");
            Console.WriteLine($"User ID: {storeC_Id[0]}");
            Console.WriteLine($"Account Number: {account_number}");
            WriteLine("= = = = = = = = = = = = =");
        }
        public string[] StoreUser { get; }
        public string[] StorePassword { get; }
        public string[] StoreCustomer { get; }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public int AccountNumber { get; }
    }
}
