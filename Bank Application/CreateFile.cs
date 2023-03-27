using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace Bank_Application
{
    public class CreateFile : Account
    {
        string fileLocation = "";
        int creationDate = 0;

        public CreateFile(string fileLocation, int creationDate) : base(user:"", password:"", name:"", account_number:0)
        {
          this.fileLocation = fileLocation;
          this.creationDate = creationDate;
        }

        public void CreateStatement(BankAccount balance)
        {
            WriteLine("= Account Statement =");
            WriteLine($"Account Owner: {User}");
            WriteLine($"Account Number #{account_number}"); //MUST MAKE PROPERTY FOR ACCOUNT NUMBER!
            WriteLine($"Balance As For {creationDate}: ${balance.Balance}");
            WriteLine("");
            WriteLine("DEPOSITS");

            //MAKE AN ARRAY IN BankAccount TO GET DEPOSIT DATA

            WriteLine($"Member Since: [CREATE NEW ATRIBUTE IN ACCOUNT CLASS]");
            WriteLine("End of Statement");
            WriteLine($"");
        }
        public void ErrorMessageForStatement()
        {
            WriteLine("There was an error trying to create your account statement");
            WriteLine("Please, try the following possible solutions: ");
            WriteLine("Make sure file location is correct and available (CRUCIAL)");
            WriteLine("If you did not create an account, please do it! Data is collected from Account Class! (CRUCIAL)");
        }
    }
}
