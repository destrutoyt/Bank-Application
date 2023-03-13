using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application
{
    public class BankAccount
    {
        public decimal Balance { get; private set; } //DECIMAL ITS MOSTLY USE FOR MONEY USES

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void AddJob(Job totalPay) //WORKING!
        {
            totalPay.DisplayPayment(); //CALCULATE TOTAL PAYMENT
            Balance += totalPay.PayTotal;
        }
        public string DisplayBalance(decimal debug) //IF VOID METHOD IS USED, IT WILL NOT RETURN AN UPDATED BALANCE!!!
        {
            return $"New Balance: {Balance:C}\nTotal Pay Registered: {debug}"; //WORKING!
        }
    }
}

