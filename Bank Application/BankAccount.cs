using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Bank_Application
{
    public class BankAccount
    {
        public List<decimal> TransactionAmount = new List<decimal>();
        public List<int> TransactionID = new List<int>();
        public List<string> TransactionName = new List<string>();

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }
        public string DisplayBalance() //IF VOID METHOD IS USED, IT WILL NOT RETURN AN UPDATED BALANCE!!!
        {
            return $"New Balance: {Balance:C}";
        }
        public void AddJob(PaySystem jobData, int transactionID, string transactionInfo)
        {
            jobData.DisplayPaycheck(); //CALCULATE TOTAL PAYMENT
            Balance += jobData.NetPay;
            TransactionAmount.Add(jobData.NetPay);
            TransactionID.Add(transactionID);
            TransactionName.Add(transactionInfo);
        }
        public void Deposit(decimal deposit, int ID, string transactionInfo)
        {
            WriteLine("Starting transaction...");
            Thread.Sleep(1000);
            WriteLine("Adding funds to your bank account...");

            Wallet -= deposit;
            Balance += deposit;
            TransactionAmount.Add(deposit);
            TransactionID.Add(ID);
            TransactionName.Add(transactionInfo);

            Thread.Sleep(1000);
            WriteLine("Transaction COMPLETED!");
            WriteLine("");
            WriteLine($"New Balance: {Balance:C}");
            WriteLine($"Wallet: {Wallet:C}");
            WriteLine("Press ANY key to go back to the menu");
            ReadKey();
            Clear();

        }
        public void Withdrawl(decimal withdrawl, int ID, string transactionInfo)
        {
            WriteLine("Starting transaction...");
            Thread.Sleep(1000);
            WriteLine("Withdrawing funds from your bank account...");

            Wallet = withdrawl;
            Balance -= withdrawl;
            TransactionAmount.Add(withdrawl);
            TransactionID.Add(ID);
            TransactionName.Add(transactionInfo);

            Thread.Sleep(1500);
            WriteLine("Transaction COMPLETED!");
            WriteLine("");
            WriteLine($"New Balance: {Balance:C}");
            WriteLine($"Wallet: {Wallet:C}");
            WriteLine("Press ANY key to go back to the menu");
            ReadKey();
            Clear();

        }
        public void OverWithdrawl(decimal withdrawl, int ID, string transactionInfo)
        {
            WriteLine("Starting transaction...");
            Thread.Sleep(1000);
            WriteLine("Withdrawing money from your bank account...");
            Thread.Sleep(1000);
            WriteLine("Applying $100 fee for OverWithdrawl");
            WriteLine("");

            Wallet = withdrawl;
            Balance -= withdrawl + 100;
            TransactionAmount.Add(withdrawl);
            TransactionID.Add(ID);
            TransactionName.Add(transactionInfo);

            Thread.Sleep(1500);
            WriteLine("Transaction COMPLETED!");
            WriteLine("");
            WriteLine($"New Balance: {Balance:C}");
            WriteLine($"Wallet: {Wallet:C}");
            WriteLine("Press ANY key to go back to the menu");
            ReadKey();
            Clear();
        }
        public decimal Balance { get; set; } //DECIMAL ITS MOSTLY USE FOR MONEY USES
        public decimal Wallet { get; set; }
    }
}
