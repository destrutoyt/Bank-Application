using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TestForClasses_BankApp
{
    public class Shopping
    {
        int[] itemPrice = { 799, 2999, 6999, 10000, 50000 };
        float salesTax = 0;
        int itemIndex;

        public Shopping(int itemIndex)
        {
            this.itemIndex = itemIndex;
        }

        public void CanBuy(string itemName, Bank bankData, int transactionID)
        { 
            WriteLine($"You are purchasing the following product: ");
            WriteLine(itemName);
            Thread.Sleep(3000);
            WriteLine("Wait while we process your transaction...");
            WriteLine($"DEBUG: ${itemPrice[itemIndex]}");

            //TO-DO: Try to inherance BankAccount class here so we can use the transactions attributes!!
            bankData.transactionId.Add(transactionID);

            WriteLine(bankData.Balance -= itemPrice[itemIndex]);
            WriteLine(bankData.Balance.ToString());
            ReadKey();     
        }
    }
}
