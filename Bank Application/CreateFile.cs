using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using System.Transactions;
using System.Collections;
using Microsoft.VisualBasic;

namespace Bank_Application
{
    public class CreateFile
    {
        string fileLocation = @"c:\temp\Statement From Bank App.txt"; //Admin can change it

        public void CreateStatement(BankAccount bankData, UserAccount userData, DateOnly today)
        {
            if (File.Exists(fileLocation))
            {
                WriteLine("We updated the statement that is already on your computer!");
                File.Delete(fileLocation);
                Thread.Sleep(5000);
                Clear();
            }

            StreamWriter addText = new StreamWriter(fileLocation, true);
            addText.WriteLine("== == == == == == == == == ACCOUNT STATEMENT == == == == == == == == ==");
            addText.WriteLine($"== == == == == == == == Generated In {today}== == == == == == == == ==");
            addText.WriteLine($"Account's Owner: {userData.Name}");
            addText.WriteLine($"Account Number: #{userData.AccountNumber}");
            addText.WriteLine($"Available Balance: {bankData.Balance:C}");
            addText.WriteLine("");
            addText.WriteLine("DEPOSITS / TRANSACTIONS");

            var transactionData = bankData.TransactionAmount.Zip(bankData.TransactionName, (a, t) => new { a, t })
                                    .Zip(bankData.TransactionID, (at, i) => new { at.a, at.t, i }); //ENUMERABLE.ZIP method to combine the three lists into a single sequence

            foreach (var data in transactionData)
            {
                addText.WriteLine($"${data.a} - Type: {data.t} - ID: {data.i}");
            }
            addText.WriteLine("");
            addText.WriteLine("== ACTIVE ACCOUNT PERKS ==");
            if (userData.storeDiscount == false && userData.taxReducer == false)
            {
                addText.WriteLine($"By the time of the statement creation, {userData.Name} does not have any premium perks");
            }
            else
            {
                if (userData.storeDiscount == true)
                {
                    addText.WriteLine($"- Store Discount -> Offers 25% OFF any purchase in the online store");
                }
                if (userData.taxReducer == true)
                {
                    addText.WriteLine($"- Tax Reducer -> Decreases sales tax by 2%");
                }
            }
            addText.WriteLine("");
            addText.WriteLine("End of Statement");
            addText.WriteLine("");
            addText.WriteLine("Created by Bank App");
            addText.WriteLine("== == == == == == == == == == == == == == == == == == == == == == == == == ");
            addText.Close();
            WriteLine($"Your Statement was created in {fileLocation}");
            WriteLine("Press ANY key to continue");
            ReadKey();
            Clear();

        }
        public void ErrorMessageStatement()
        {
            WriteLine("There was an error trying to create your account statement");
            WriteLine("Please, try the following possible solution:");
            WriteLine("Make sure you have more transactions. You need to have a least TWO deposits or transactions");
        }
    }
}
