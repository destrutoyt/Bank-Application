using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Bank_Application
{
    public class BankAccount //WILL WORK ON THIS ON NEXT UPDATE!
    {
        public List<decimal> transactionAmount = new List<decimal>();
        public List<int> transactionId = new List<int>();  //Remove it?
        public List<string> transactionType = new List<string>(); 

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }
        public string DisplayBalance() //IF VOID METHOD IS USED, IT WILL NOT RETURN AN UPDATED BALANCE!!!
        {
            return $"New Balance: {Balance:C}";
        }
        public void AddJob(Job jobData, int transactionID, string transactionInfo)
        {
            jobData.DisplayPaycheck(); //CALCULATE TOTAL PAYMENT
            Balance += jobData.PayTotal;
            transactionAmount.Add(jobData.PayTotal);
            transactionId.Add(transactionID);
            transactionType.Add(transactionInfo);
        }
        public void Deposit(decimal deposit, int transactionID, string transactionInfo)
        {
            WriteLine("Starting transaction...");
            Thread.Sleep(1000);
            WriteLine("Adding funds to your bank account...");

            Wallet -= deposit;
            Balance += deposit;
            transactionAmount.Add(deposit);
            transactionId.Add(transactionID);
            transactionType.Add(transactionInfo);

            Thread.Sleep(1000);
            WriteLine("Transaction COMPLETED!");
            WriteLine("");
            WriteLine($"New Balance: {Balance:C}");
            WriteLine($"Wallet: {Wallet:C}");
            WriteLine("Press ANY key to go back to the menu");
            ReadKey();
            Clear();

        }
        public void Withdrawl(decimal withdrawl, int transactionID, string transactionInfo)
        {
            WriteLine("Starting transaction...");
            Thread.Sleep(1000);
            WriteLine("Withdrawing funds from your bank account...");

            Wallet = withdrawl;
            Balance -= withdrawl;
            transactionAmount.Add(withdrawl);
            transactionId.Add(transactionID);
            transactionType.Add(transactionInfo);

            Thread.Sleep(1500);
            WriteLine("Transaction COMPLETED!");
            WriteLine("");
            WriteLine($"New Balance: {Balance:C}");
            WriteLine($"Wallet: {Wallet:C}");
            WriteLine("Press ANY key to go back to the menu");
            ReadKey();
            Clear();

        }
        public void OverWithdrawl(decimal withdrawl, int transactionID, string transactionInfo)
        {
            WriteLine("Starting transaction...");
            Thread.Sleep(1000);
            WriteLine("Withdrawing funds from your bank account...");
 
            withdrawl += 100;
            Wallet = withdrawl;
            Balance -= withdrawl;
            transactionAmount.Add(withdrawl);
            transactionId.Add(transactionID);
            transactionType.Add(transactionInfo);

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
        public decimal Wallet { get; set; } //READY TO TEST!
    }
}