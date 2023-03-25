using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForClasses_BankApp
{
    class Bank
    {
        public decimal Balance { get; set; }
        public string AccountName { get; set; }

        public Bank(string Name, decimal Balance)
        {
            this.AccountName = Name;
            this.Balance = Balance;
        }

        public void ReturnNewBalance(Job totalPay)
        {
            Console.WriteLine("Past Balance: {0}", Balance);
            Balance += totalPay.Pay;
            Console.WriteLine($"You are {AccountName}. Your new balance is {Balance} because you were getting pay {totalPay.PayRate}/h!");
        }

        public void WithdrawlMoney(Withdrawl takeOut)
        {
            Balance -= takeOut.TakeOut;
            Console.WriteLine("You took ${0} out of your account and now you have ${1} in your balance", takeOut.TakeOut, Balance);
        }
    }
}
