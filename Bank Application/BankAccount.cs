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
        public decimal Balance { get; set; } //DECIMAL ITS MOSTLY USE FOR MONEY USES
        public decimal Wallet { get; set; } //READY TO TEST!
        public int Transactions { get; set; } //SOON

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void AddJob(Job totalPay)
        {
            totalPay.DisplayPaycheck(); //CALCULATE TOTAL PAYMENT
            Balance += totalPay.PayTotal;
        }
        public string DisplayBalance() //IF VOID METHOD IS USED, IT WILL NOT RETURN AN UPDATED BALANCE!!!
        {
            return $"New Balance: {Balance:C}";
        }
        public void Withdrawl(decimal withdrawl)
        {
            WriteLine("Starting Withdrawl... (AFTER FIRST LOOP)");
            Thread.Sleep(2000);
            WriteLine($"Withdrawl Amount: {withdrawl}");
            Wallet = withdrawl;
            Balance -= withdrawl;
            WriteLine("Counting Bills...");
            Thread.Sleep(2000);
            WriteLine("FINISH!");
            //Add transaction to list
            WriteLine("RECEIPT");
            WriteLine($"New Balance: {Balance:C}");
            WriteLine($"Wallet: {Wallet:C}");
            WriteLine("Press ANY key to go back to the menu");
            ReadLine();
            Clear();
        }
        public void OverWithdrawl(decimal withdrawl)
        {
            WriteLine("Starting Withdrawl...");
            Thread.Sleep(2000);
            withdrawl += 100;
            WriteLine($"Withdrawl Amount: {withdrawl}");
            Wallet = withdrawl;
            Balance -= withdrawl;
            WriteLine("Counting Bills...");
            Thread.Sleep(2000);
            Clear();
            WriteLine("FINISH!");
            //Add transaction to list
            WriteLine("RECEIPT");
            WriteLine($"New Balance: {Balance:C}");
            WriteLine($"Wallet: {Wallet:C}");
            WriteLine("Press ANY key to go back to the menu");
            ReadLine();
            Clear();
        }
    }
}