using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Bank_Application
{
    public class ShopItem
    {
        public int[] itemPrice = { 799, 2999, 6999, 10000, 50000 };
        const double TAXRATE = 0.0575; //Cannot be changed
        public decimal subTotal = 0, taxAmount = 0, totalPrice = 0;
        public bool payVerification = false; //Verify if balance is enough to cover payment
        int itemIndex;

        public ShopItem(int itemIndex)
        {
            this.itemIndex = itemIndex;
        }

        public bool VerifyPayment(BankAccount bankData)
        {
            taxAmount = (decimal)(itemPrice[itemIndex] * TAXRATE); // Ex. A * 5.75 ----> A would be number from the array itemPrice depending on the index inputed. 
            subTotal = itemPrice[itemIndex];
            totalPrice = subTotal + taxAmount;
            if (bankData.Balance < totalPrice)
            {
                return payVerification = false;
            }
            else
            {
                return payVerification=true;
            }
        }
        public void PurchasingProduct(string itemName, BankAccount bankData, int transactionID, string transactionType)
        {
            WriteLine($"You are purchasing the following product: ");
            WriteLine(itemName);
            Thread.Sleep(2500);
            WriteLine("Wait while we process your transaction...");

            bankData.transactionId.Add(transactionID);
            bankData.transactionType.Add(transactionType);
            bankData.transactionAmount.Add(totalPrice);
            bankData.Balance -= totalPrice;
            Thread.Sleep(2500);
            Clear();

            WriteLine($"== RECEIPT #{transactionID} ==");
            WriteLine("");
            WriteLine("Products Purchased: ");
            WriteLine(itemName);
            WriteLine("");
            WriteLine($"Sub-Total: ${subTotal}");
            WriteLine($"Sales Tax (5.75%): ${taxAmount}");
            WriteLine($"Total: ${totalPrice}");
            WriteLine("");
            WriteLine("Thank you for purchase!");
            WriteLine("Press ANY key to continue");
            ReadKey();
            Clear();

        }
        public void PaymentDenied()
        {
            WriteLine("Ups! Your payment was denied due to insufficient funds. Please, remember that your bank has a Anti-Debt System which helps you prevent debts.");
            WriteLine("Please, try again once you have enough funds to cover the transaction. Do know that there is a 5.75% sales TAX per purchase");
            WriteLine("Press ANY key to continue");
            ReadKey();
            Clear();
        }
    }
}
