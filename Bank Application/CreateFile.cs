using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using System.Transactions;
using System.Collections;

namespace Bank_Application
{
    public class CreateFile //CLASS IS ON HEAVY DEVELOPMENT
    {
        string fileLocation = @"c:\temp\Statement From Bank App2.txt";
        int creationDate = 0;

        public void CreateStatement(BankAccount bankData, Account userData)
        {
            if (File.Exists(fileLocation))
            {
                WriteLine("We updated the statement that is already on your computer!");
                File.Delete(fileLocation);
                Thread.Sleep(5000);
                Clear();
            }

            StreamWriter addText = new StreamWriter(fileLocation, true);
            addText.WriteLine("= Account Statement =");
            addText.WriteLine($"Account Owner: {userData.Name}");
            addText.WriteLine($"Account Number #{userData.AccountNumber}"); //MUST MAKE PROPERTY FOR ACCOUNT NUMBER!
            addText.WriteLine($"Balance As For {creationDate}: ${bankData.Balance}");
            addText.WriteLine("");
            addText.WriteLine("DEPOSITS / TRANSACTIONS");

            var transactionData = bankData.transactionAmount.Zip(bankData.transactionType, (a, t) => new { a, t })
                                    .Zip(bankData.transactionId, (at, i) => new { at.a, at.t, i }); //ENUMERABLE.ZIP method to combine the three lists into a single sequence

            foreach (var data in transactionData)
            {
                addText.WriteLine($"${data.a} - Type: {data.t} - ID: {data.i}");
            }
            WriteLine("");
            addText.WriteLine($"Member Since: [CREATE NEW ATRIBUTE IN ACCOUNT CLASS]");
            addText.WriteLine("End of Statement");
            addText.WriteLine($"");
            addText.Close();
        }
        public void ErrorMessageStatement()
        {
            WriteLine("There was an error trying to create your account statement");
            WriteLine("Please, try the following possible solution:");
            WriteLine("Make sure you have more transactions. You need to have a least TWO deposit or transaction");
        }
    }
}
