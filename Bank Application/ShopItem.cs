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
        public string[] shopProducts = { "- PS5 Bundle ($799)", "- High-End PC ($2999)", "- Luxury Clothes ($6999)", "- Used 2010 Nissan Sentra ($10000)", "- 2023 Nissan GTR ($50000)" };
        public int[] itemPrice = { 799, 2999, 6999, 10000, 50000 };
        double TAXRATE = 0.0575; //Can be changed
        decimal subTotal = 0, taxAmount = 0, totalPrice = 0, discount = 0;
        public bool payVerification = false; //Verify if balance is enough to cover payment
        int itemIndex;



        public ShopItem(int itemIndex)
        {
            this.itemIndex = itemIndex;
        }

        public void DisplayShopProducts()
        {
            foreach(string i in shopProducts)
            {
                WriteLine(i);
            }
        }
        public bool VerifyPayment(BankAccount bankData, Account upgrades)
        {
            if (upgrades.taxReducer == true)
            {
                WriteLine("= Discounts =");
                TAXRATE -= 0.0225;
                WriteLine("Sales Tax reduced by 2.25%");

                subTotal = itemPrice[itemIndex];
                taxAmount = (decimal)(itemPrice[itemIndex] * TAXRATE); // Ex. A * 5.75 ----> A would be number from the array itemPrice depending on the index inputed.

                if (upgrades.storeDiscount == true)
                {
                    discount = subTotal / 25;
                    totalPrice = subTotal + taxAmount;
                    WriteLine("25% Store Discount Applied");
                }
            }
            else
            {
                subTotal = itemPrice[itemIndex];
                taxAmount = (decimal)(itemPrice[itemIndex] * TAXRATE); // Ex. A * 5.75 ----> A would be number from the array itemPrice depending on the index inputed.
            }
            totalPrice = subTotal + taxAmount - discount;

            if (bankData.Balance < totalPrice)
            {
                return payVerification = false;
            }
            else
            {
                return payVerification=true;
            }
        }
        public void PurchasingProduct(BankAccount bankData, int transactionID, string transactionType)
        {
            WriteLine("");
            WriteLine($"You are purchasing the following product: ");
            WriteLine(shopProducts[itemIndex]);
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
            WriteLine(shopProducts[itemIndex]);
            WriteLine("");
            WriteLine($"Sub-Total: ${subTotal}");
            WriteLine($"Discount: ${discount}");
            WriteLine($"Sales Taxes: ${taxAmount}");
            WriteLine($"Total: ${totalPrice}");
            WriteLine("");
            WriteLine("Thank you for purchase!");
            WriteLine("Press ANY key to continue");
            ReadKey();
            Clear();

        }
        public void PaymentDenied()
        {
            WriteLine("Ups! Your payment was denied due to insufficient funds.");
            WriteLine("Please, try again once you have enough funds to cover the transaction. TIP: Purchase an Account Upgrade to lower the total price");
            WriteLine("Press ANY key to continue");
            ReadKey();
            Clear();
        }
    }
}
