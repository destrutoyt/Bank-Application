using Bank_Application;
using System.Security.Principal;
using System.Text.RegularExpressions;
using static System.Console;

class Program
{
    static public void Main(String[] args)
    {
        // OFFICIAL RELEASE by Miguel Angel Garces Lenis (ReWorked Version 2.5)

        //REGISTRATION / LOGIN
        string user = "test", pass = "test", firstName = "test", loginUser, loginPass;

        //JOB
        decimal payRate = 12;
        int weeksWorked = 0;
        decimal payRaise = 2;

        //TRANSACTIONS & SHOP
        Random random = new Random();
        int bank_account = random.Next(10000, 99999); //Creates a random number for account number
        int randomID = random.Next(100, 999);
        bool hasAccess = false;
        string[] shopItems = {"- PS5 Bundle ($799)", "- High-End PC ($2999)", "- Luxury Clothes ($6999)", "- Used 2010 Nissan Sentra ($10000)", "- 2023 Nissan GTR ($50000)", };

        //OTHERS
        int selection = 0, input = 0; //MENU SELECTION
        string stringInput = "";
        decimal deposit = 0, withdrawl = 0;

        //OBJECTS
        var bankAccount = new BankAccount(100m); //START WITH $100 BALANCE BY CREATING NEW ACCOUNT
        var jobDetails = new Job(0, 0);
        Account? Profile = null;  //initiate a null object QUESTION MARK IS REQUIRED FOR NULLABLE TYPES
        CreateFile BankStatement = new CreateFile();
        ShopItem? ItemShop = null;

    StartOfProgram:
        while (true) //GOES BACK TO MENU IF TRUE
        {
            try
            {
                WriteLine("Welcome to your Online Bank");
                WriteLine("\n");

                WriteLine("== MENU ==");
                WriteLine("1. Registration");
                WriteLine("2. Log In");
                WriteLine("3. Admin Access");
                WriteLine("4. Exit");
                Write("Enter your option (ONLY NUMBERS ALLOWED): ");
                selection = Convert.ToInt16(ReadLine());
            }
            catch
            {
                WriteLine("You did not inserted a numeric input (0-9)!");
                Thread.Sleep(3000);
                Clear();
            }

            WriteLine("");
            switch (selection)
            {
                case 1: //REGISTRATION
                    Clear();
                    Write("New User: ");
                    user = ReadLine();
                    WriteLine("Saving..");
                    Thread.Sleep(2000); //DELAY 2 SECONDS (2000)
                    WriteLine("\n");

                    WriteLine("REQUIREMENTS:\n1. Must be at least 5 characters long\n2. Cannot be your username\n");
                    Write("Set Password: ");
                    pass = ReadLine();
                    while (pass == user || pass.Length < 5)
                    {
                        WriteLine("Ups! you did not follow our requirements :(");
                        Write("TRY AGAIN! Set Password: ");
                        pass = ReadLine();
                        WriteLine("\n");
                    }
                    WriteLine("Saving..");
                    Thread.Sleep(2000); //DELAY 2 SECONDS
                    WriteLine("\n");

                    Write("First Name: ");
                    firstName = Convert.ToString(ReadLine());

                    while (firstName == user || firstName.Length > 100 || !Regex.IsMatch(firstName, "^[a-zA-Z\\s]*$"))
                    {
                        WriteLine("ERROR! You inserted an invalid name");
                        Write("First Name: ");
                        firstName = Convert.ToString(ReadLine());
                        WriteLine("\n");
                    }
                    Clear();
                    WriteLine("Saving..");
                    Thread.Sleep(1000); //DELAY 1 SECOND
                    Profile = new Account(user, pass, firstName, bank_account); //creates a new object
                    WriteLine("Creating Account..");
                    Thread.Sleep(1000); //DELAY 1 SECOND

                    Clear();
                    Profile.Details(); //Calls Details method
                    WriteLine("\n");
                    WriteLine($"Welcome To Your Online Bank, Mr/Ms {firstName}!");
                    WriteLine("You are now able to log-in into your account!");
                    WriteLine("Press ANY key to continue");
                    ReadKey();
                    Clear();
                    break;

                case 2:
                    Clear();
                    if (Profile == null)
                    {
                        WriteLine("There are no accounts registered. Please, register a new account before trying to log-in");
                        WriteLine("Press ANY key to continue");
                        ReadKey();
                        break;
                    }
                    else
                    {
                        WriteLine("== LOG-IN ==");
                        Write("Username: ");
                        loginUser = ReadLine();
                        Write("Password: ");
                        loginPass = ReadLine();
                        WriteLine("\n");
                    }

                    while (loginUser != user || loginPass != pass)
                    {
                        WriteLine("ERROR! The password or username entered are incorrect!");
                        Write("Username: ");
                        loginUser = ReadLine();
                        Write("Password: ");
                        loginPass = ReadLine();
                        WriteLine("\n");
                    }
                    Clear();
                    while (true)
                    {
                        WriteLine(" = Welcome Back {0}! = ", firstName);
                        WriteLine("MENU");
                        WriteLine("1. Account Information");
                        WriteLine("2. Work");
                        WriteLine("3. Withdrawl");
                        WriteLine("4. Deposit");
                        WriteLine("5. Shop");
                        WriteLine("6. Get Statement");
                        WriteLine("7. Log-Off");
                        try
                        {
                            Write("Selection (MUST BE A NUMBER): ");
                            selection = Convert.ToInt32(ReadLine());
                        }
                        catch
                        {
                            WriteLine("ERROR! You did not inserted a numeric value !");
                        }
                        switch (selection)
                        {
                            case 1:
                                Clear();
                                WriteLine("Loading Account Information...");
                                Thread.Sleep(2000);
                                Clear();

                                Profile.AccountInformation(bankAccount);
                                WriteLine("");
                                WriteLine("Press ANY key to continue");
                                ReadKey();
                                Clear();
                                break;
                            case 2:
                                try
                                {
                                    Clear();
                                    WriteLine("");
                                    WriteLine("= WORK TIME =");
                                    WriteLine($"Current PayRate: ${payRate}/h - +${payRaise}/h per 5 weeks worked");
                                    WriteLine($"Weeks Worked: {weeksWorked}");
                                    WriteLine("");
                                    Write("How many hours would you like to work this week? (MAX 40): ");

                                    input = Convert.ToInt32(ReadLine());
                                }
                                catch
                                {
                                    WriteLine("ERROR! You did not inserted a correct number (0-40)!");
                                }

                                while (input < 0 || input > 40)
                                {
                                    WriteLine("Ups! You are either working too much or doing less than 0 hours!");
                                    Write("TRY AGAIN! How many hours would you like to work this week? (MAX 40): ");
                                    input = Convert.ToInt32(ReadLine());
                                }
                                Clear();
                                WriteLine("Working.....");
                                Thread.Sleep(input * 100);
                                jobDetails = new Job(payRate, input);
                                randomID = random.Next(100, 999);
                                bankAccount.AddJob(jobDetails, randomID, "Work Pay");
                                weeksWorked++;
                                Clear();

                                if (weeksWorked % 5 == 0)
                                {
                                    WriteLine($"CONGRATULATIONS! You were given a raise of +${payRaise} for your hourly payrate");
                                    payRate += payRaise;
                                    WriteLine($"New Rate Available On Next Paycheck: ${payRate}/h");
                                    WriteLine("");
                                }
                                WriteLine("You worked really hard this week!");
                                WriteLine("Keep up the amazing job and you might get a raise!");
                                WriteLine("");
                                WriteLine($"DETAILS:"); //ERROR FIXED 3/6/2023
                                jobDetails.DisplayPaycheck();
                                WriteLine(bankAccount.DisplayBalance());
                                WriteLine("");
                                WriteLine("Press ANY key to go back to menu");
                                ReadKey();
                                Clear();
                                break;
                            case 3: //Added new Methods!
                                Clear();
                                try
                                {
                                    WriteLine("= ATM MACHINE =");
                                    WriteLine($"Available Balance: {bankAccount.Balance:C}");
                                    WriteLine("");
                                    Write("How much money would you like to withdrawl? $");
                                    withdrawl = Convert.ToDecimal(ReadLine());
                                }
                                catch
                                {
                                    WriteLine("Your input is NOT numeric! Going back to main menu!");
                                    Thread.Sleep(4000);
                                    Clear();
                                    break;
                                }

                                if (withdrawl > bankAccount.Balance)
                                {
                                    Clear();
                                    WriteLine("ATTENTION");
                                    WriteLine("You are trying to withdrawl more money than you have");
                                    WriteLine("If you continue, you will be charged $100 as a fee");
                                    Write("Would you like to continue? (Y/N) > ");
                                    stringInput = Convert.ToString(ReadLine().ToUpper());

                                    if (stringInput == "Y" || stringInput == "YES")
                                    {
                                        randomID = random.Next(100, 999);
                                        bankAccount.OverWithdrawl(withdrawl, randomID, "Withdrawl");
                                        break;
                                    }
                                    else
                                    {
                                        Clear();
                                        break;
                                    }
                                }
                                else
                                {
                                    randomID = random.Next(100, 999);
                                    bankAccount.Withdrawl(withdrawl, randomID, "Withdrawl");
                                    break;
                                }

                            case 4:
                                Clear();
                                try
                                {
                                    WriteLine("= ATM MACHINE =");
                                    WriteLine($"Wallet: {bankAccount.Wallet:C}");
                                    WriteLine("");
                                    Write("How much money would you like to deposit to your bank account? $");
                                    deposit = Convert.ToDecimal(ReadLine());
                                }
                                catch
                                {
                                    WriteLine("Your input is NOT numeric! Going back to main menu!");
                                    Thread.Sleep(3500);
                                    Clear();
                                    break;
                                }
                                if (deposit > bankAccount.Wallet)
                                {
                                    Clear();
                                    WriteLine("ATTENTION");
                                    WriteLine("You don't have this amount of money to deposit");
                                    WriteLine("Closing ATM....");
                                    Thread.Sleep(3500);
                                    Clear();
                                    break;
                                }
                                else
                                {
                                    randomID = random.Next(100, 999);
                                    bankAccount.Deposit(deposit, randomID, "Deposit");
                                    break;
                                }

                            case 5:
                                Clear();
                                WriteLine("== Shopping Store ==");
                                WriteLine("NOTE: You are limited to ONE item!");
                                WriteLine("");
                                WriteLine("Available Products:");
                                foreach (string i in shopItems)
                                {
                                   WriteLine(i);
                                }
                                try
                                {
                                    Write("");
                                    Write("Which one would you like to buy? (0-5)");
                                    input = Convert.ToInt32(ReadLine());
                                }
                                catch
                                {
                                    WriteLine("Your input is NOT numeric! Going back to main menu!");
                                    Thread.Sleep(3500);
                                    Clear();
                                    break;
                                }
                                while (input > 5)
                                {
                                    WriteLine("You must pick a number between 0 to 5");
                                    Write("TRY AGAIN! Which one would you like to buy? (0-5)");
                                    input = Convert.ToInt32(ReadLine());
                                }
                                Clear();
                                ItemShop = new ShopItem(input);
                                ItemShop.VerifyPayment(bankAccount);

                                if (ItemShop.payVerification == false)
                                {
                                    ItemShop.PaymentDenied();
                                    break;
                                }
                                else
                                {
                                    ItemShop.PurchasingProduct(shopItems[input], bankAccount, randomID, "Purchase");
                                    break;
                                }
                            case 6:
                                Clear();
                                if (bankAccount.transactionId.Count < 1)
                                {
                                    BankStatement.ErrorMessageStatement();
                                    Thread.Sleep(5000);
                                    break;
                                }
                                else
                                {
                                    BankStatement.CreateStatement(bankAccount, Profile, DateTime.Now);
                                    break;

                                }
                            case 7: //WILL WORK ON CONFIRMATION FEATURE SOON
                                Clear();
                                goto StartOfProgram; // (Must be removed)

                            default:
                                {
                                    WriteLine("DEBUG: Invalid input");
                                    Clear();
                                    break;
                                }
                        }
                    }
                case 3:
                    WriteLine("ADMIN CONTROL COMING SOON");
                    break;
                case 4:
                    WriteLine("Exiting app...");
                    Thread.Sleep(2500);
                    Clear();
                    Environment.Exit(1);
                    break;

                default:
                    {
                        WriteLine("DEBUG: Invalid input");
                        Clear();
                        break;
                    }
            }
        }
    }
}
//END OF CODE
