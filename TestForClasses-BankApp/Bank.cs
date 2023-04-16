using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForClasses_BankApp
{
    public class Bank
    {
        public decimal Balance { get; set; }
        public string AccountName { get; set; }
        public List<decimal> transactionAmount = new List<decimal>();
        public List<int> transactionId = new List<int>();
        public List<string> transactionType = new List<string>();

        public Bank(string Name, decimal Balance)
        {
            this.AccountName = Name;
            this.Balance = Balance;
        }
        public int Transaction()
        {
            return transactionId[0];
        }
    }
}
