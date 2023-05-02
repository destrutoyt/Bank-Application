﻿using System;
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
        decimal TAXRATE = 0.0657m; //6.57% Sales Tax which is the average US sales tax
        decimal subTotal, taxAmount, totalPrice, discount;
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
            subTotal = itemPrice[itemIndex];

            if (upgrades.taxReducer == true)
            {
                TAXRATE -= 0.02m;
            }
            if (upgrades.storeDiscount == true)
            {
                discount = subTotal / 25;
            }

            taxAmount = (decimal)(itemPrice[itemIndex] * TAXRATE);
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
        public void PurchasingProduct(Account upgrades, BankAccount bankData, int transactionID, string transactionType)
        {
            subTotal = itemPrice[itemIndex];
            WriteLine("= Discounts =");
            if (upgrades.taxReducer == true)
            {
                TAXRATE -= 0.02m;
                WriteLine("Sales Tax Reduced By 3.5%");
            }
            else
            {
                WriteLine("Tax Discount NOT purchased!");
            }
            if (upgrades.storeDiscount == true)
            {
                discount = subTotal / 25;
                WriteLine("25% Store Discount Applied");
            }
            else
            {
                WriteLine("Store Discount NOT purchased!");
            }

            taxAmount = (decimal)(itemPrice[itemIndex] * TAXRATE);
            totalPrice = subTotal + taxAmount - discount;

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
            WriteLine($"Discount: -${discount}");
            WriteLine($"Sales Taxes ({TAXRATE.ToString("P2")}): ${taxAmount}");
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
