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
        public decimal pay { get; private set; }

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void AddJob(decimal payment) //BEFORE THIS WAS (Job job) not recommended tho
        {
            Balance += payment;
        }
        public string DisplayBalance() //IF VOID METHOD IS USED, IT WILL NOT RETURN AN UPDATED BALANCE!!!
        {
            return $"New Balance: ${Balance:C} HOURS WERE: {pay}"; //NOTDISPLAYING UPDATED BALANCE
        }
    }
}

