using Bank_Application;
using System.Security.Principal;
using System.Text.RegularExpressions;
using static System.Console;

class Program
{
    static public void Main(String[] args)
    {
        // OFFICIAL RELEASE by Miguel Angel Garces Lenis (ReWorked Version 3.0)

        //REGISTRATION / LOGIN
        string user = "test", pass = "test", firstName = "test", loginUser, loginPass;

        //JOB
        decimal payRate = 14;
        int weeksWorked = 0;
        decimal payRaise = 2;
        decimal extraFees = 0;

        //TRANSACTIONS & SHOP
        Random random = new Random();
        int accountNumber = random.Next(10000, 99999); //Creates a random number for account number
        int randomID = random.Next(100, 999);
        decimal deposit = 0, withdrawl = 0;

        //OTHERS
        int selection = 0, input = 0; //MENU SELECTION VARIABLES
        string stringInput = "";

        //OBJECTS
        var bankAccount = new BankAccount(50m); //START WITH $50 BALANCE BY CREATING NEW ACCOUNT
        var jobDetails = new Job(0, 0, 0);
        Account? Profile = null;  //initiate a null object QUESTION MARK IS REQUIRED FOR NULLABLE TYPES
        CreateFile BankStatement = new CreateFile();
        ShopItem ItemShop = new ShopItem(0);

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
                    Profile = new Account(user, pass, firstName, accountNumber); //creates a new object
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
                        WriteLine("");
                        WriteLine("MENU");
                        WriteLine("1. Account Info / Upgrades");
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
                                Thread.Sleep(1500);
                                Clear();

                                Profile.AccountInformation(bankAccount);
                                WriteLine("");
                                Thread.Sleep(1500);
                                if (Profile.taxReducer == false || Profile.storeDiscount == false)
                                {
                                    try
                                    {
                                        WriteLine("There are upgrades available for your profile!");
                                        Write("Would you like to purchase an upgrade? (Y/N):");
                                        stringInput = Convert.ToString(ReadLine().ToUpper());
                                    }
                                    catch
                                    {
                                        WriteLine("Response is not a letter!");
                                    }
                                    if (stringInput == "Y" || stringInput == "YES")
                                    {
                                        if (bankAccount.Balance < 1500)
                                        {
                                            Clear();
                                            WriteLine("Your balance does not meet our requirement > Have more than $1500 in your balance");
                                            WriteLine("Press ANY key to continue");
                                            ReadKey();
                                            Clear();
                                        }
                                        else
                                        {
                                            Clear();
                                            WriteLine("UPGRADES AVAILABLE");
                                            if (Profile.taxReducer == false)
                                            {
                                                WriteLine("Tax Reducer ($250) > Reduces the sales tax by 2.25% for all purchases");
                                            }
                                            if (Profile.storeDiscount == false)
                                            {
                                                WriteLine("Store Discount ($250) > Get a 25% discount for all purchases");
                                            }

                                            try
                                            {
                                                WriteLine("");
                                                WriteLine("NOTE: Upgrades are paid every paycheck");
                                                Write("Which upgrade would you like to purchase? (Type the first word of the upgrade or any other input to quit): ");
                                                stringInput = Convert.ToString(ReadLine().ToUpper());
                                            }
                                            catch
                                            {
                                                WriteLine("Response is not a letter!");

                                            }
                                            if (stringInput == "STORE")
                                            {
                                                if (Profile.storeDiscount == true)
                                                {
                                                    WriteLine("You already own this purchase. Returning to main menu...");
                                                    Thread.Sleep(2000);
                                                    Clear();
                                                    break;
                                                }
                                                else
                                                {
                                                    Profile.ProfileUpgrades(bankAccount, 250, "STORE", "Upgrade (No-ID)");
                                                    break;
                                                }
                                            }

                                            if (stringInput == "TAX")
                                            {
                                                if (Profile.taxReducer == true)
                                                {
                                                    WriteLine("You already own this purchase. Returning to main menu...");
                                                    Thread.Sleep(2000);
                                                    Clear();
                                                    break;
                                                }
                                                else
                                                {
                                                    Profile.ProfileUpgrades(bankAccount, 250, "TAX", "Upgrade (No-ID)");
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                WriteLine("Going back to menu...");
                                                Thread.Sleep(2500);
                                                Clear();
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Clear();
                                        break;
                                    }
                                }
                                else
                                {
                                    WriteLine("");
                                    WriteLine("Press ANY key to continue");
                                    ReadKey();
                                    Clear();
                                    break;
                                }
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
                                if (Profile.taxReducer == true)
                                {
                                    extraFees = 250;

                                    if (Profile.storeDiscount == true)
                                    {
                                        extraFees += 250;
                                    }
                                }
                                Thread.Sleep(input * 100);
                                jobDetails = new Job(payRate, input, extraFees);
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
                                WriteLine("Keep working hard and you will get a raise!");
                                WriteLine("");
                                jobDetails.DisplayPaycheck();
                                WriteLine(bankAccount.DisplayBalance());
                                WriteLine("");
                                WriteLine("Press ANY key to go back to menu");
                                ReadKey();
                                Clear();
                                break;
                            case 3:
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
                                ItemShop.DisplayShopProducts();
                                WriteLine("");
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
                                ItemShop.VerifyPayment(bankAccount, Profile);

                                if (ItemShop.payVerification == false)
                                {
                                    ItemShop.PaymentDenied();
                                    break;
                                }
                                else
                                {
                                    ItemShop.PurchasingProduct(bankAccount, randomID, "Purchase");
                                    break;
                                }
                            case 6:
                                Clear();
                                if (bankAccount.transactionId.Count < 1)
                                {
                                    WriteLine();
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
