using Bank_Application;
using System.Security.Principal;
using System.Text.RegularExpressions;
using static System.Console;

class Program
{
    static public void Main(String[] args)
    {
        // OFFICIAL RELEASE by Miguel Angel Garces Lenis (ReWorked Version 4.0-FINAL)

        //REGISTRATION / LOGIN
        string user = "test", pass = "test", firstName = "test", loginUser, loginPass;

        //JOB
        int weeksWorked = 0;
        int weeksLeft = 10;
        int levelIndex = 0;
        decimal extraFees = 0;

        //TRANSACTIONS & SHOP
        Random random = new Random();
        int accountNumber = random.Next(10000, 99999); //Creates a random number for account number
        int randomID = random.Next(100, 999);
        decimal deposit = 0, withdrawl = 0;

        //OTHERS
        int selection = 0, input = 0; //MENU SELECTION VARIABLES
        string stringInput = "";
        bool breakFlag = true;

        //OBJECTS
        var bankAccount = new BankAccount(5000m); //START WITH $50 BALANCE BY CREATING NEW ACCOUNT
        var payDetails = new PaySystem(0, 0, 0);
        var jobDetails = new Jobs();
        UserAccount Profile = new("test", "test", "test", 0);  //initiate a null object QUESTION MARK IS REQUIRED FOR NULLABLE TYPES
        CreateFile BankStatement = new CreateFile();
        ShopItem ItemShop = new ShopItem(0);

        while (true) //GOES BACK TO MENU IF TRUE
        {
            try
            {
                WriteLine("Welcome to your Online Bank");
                WriteLine("\n");

                WriteLine("== MENU ==");
                WriteLine("1. Registration");
                WriteLine("2. Log In");
                WriteLine("3. Exit");
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

                    while (string.IsNullOrWhiteSpace(firstName) || firstName == user || firstName.Length > 30 || !Regex.IsMatch(firstName, "^[a-zA-Z\\s]*$"))
                    {
                        WriteLine("ERROR! You inserted an invalid name");
                        Write("First Name: ");
                        firstName = Convert.ToString(ReadLine());
                        WriteLine("\n");
                    }
                    Clear();
                    WriteLine("Saving..");
                    Thread.Sleep(1000); //DELAY 1 SECOND
                    Profile = new UserAccount(user, pass, firstName, accountNumber); //creates a new object
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
                    while (breakFlag==true)
                    {
                        breakFlag = true;
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
                                                WriteLine("Tax Reducer ($300) > Reduces the sales tax by 2% for all purchases");
                                            }
                                            if (Profile.storeDiscount == false)
                                            {
                                                WriteLine("Store Discount ($500) > Get a 25% discount for all purchases");
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
                                                    Profile.PremiumPerks(bankAccount, 500, "STORE", "Premium Perk (No-ID)");
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
                                                    Profile.PremiumPerks(bankAccount, 250, "TAX", "Premium Perk (No-ID)");
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
                                Clear();
                                while (breakFlag == true)
                                {
                                    try
                                    {
                                        WriteLine("= JOB MENU =");
                                        WriteLine("1. Apply for a Job");
                                        WriteLine("2. Dashboard");
                                        WriteLine("3. Work");
                                        WriteLine("4. Quit Job");
                                        WriteLine("5. Exit");
                                        Write("SELECTION: ");
                                        input = Convert.ToInt32(ReadLine());
                                    }
                                    catch
                                    {
                                        WriteLine("You did not inserted a numeric input (0-9)!");
                                        Thread.Sleep(3000);
                                        Clear();
                                    }
                                    switch (input)
                                    {
                                        case 1:
                                            Clear();
                                            if (jobDetails.hasJob == false)
                                            {
                                                jobDetails.JobSelection(payDetails);
                                            }
                                            else
                                            {
                                                WriteLine("You are currently an employee! You cannot have more than ONE job!");
                                                WriteLine("Press ANY key to continue");
                                                ReadLine();
                                            }
                                            Clear();
                                            break;
                                        case 2:
                                            Clear();
                                            if (jobDetails.hasJob == true)
                                            {
                                                jobDetails.JobDashboard(payDetails, levelIndex, weeksLeft);
                                            }
                                            else
                                            {
                                                WriteLine("You don't have access to a dashboard since you are not an employer\nApply at any job before accessing this menu!");
                                                WriteLine("Press ANY key to continue");
                                                ReadLine();
                                            }
                                            Clear();
                                            break;
                                        case 3:
                                            if (jobDetails.hasJob == true)
                                            {
                                                try
                                                {
                                                    Clear();
                                                    WriteLine("");
                                                    WriteLine("= TIME TO START YOUR SHIFT! =");
                                                    WriteLine($"Weeks Worked: {weeksWorked}");
                                                    if (levelIndex == 2)
                                                    {
                                                        WriteLine("You are currently a Senior at your position. So, there are not weeks left to level up!");
                                                    }
                                                    else
                                                    {
                                                        WriteLine($"Weeks Left for Next Level: {weeksLeft}");
                                                    }
                                                    WriteLine("");
                                                    Write("How many hours would you like to work this week? (MIN 20 - MAX 40): ");

                                                    input = Convert.ToInt32(ReadLine());
                                                }
                                                catch
                                                {
                                                    WriteLine("ERROR! You did not inserted a correct number (20-40)!");
                                                }
                                                while (input < 20 || input > 40)
                                                {
                                                    WriteLine("Ups! You are either working too much or doing less than 20 hours!");
                                                    Write("TRY AGAIN! How many hours would you like to work this week? (MIN 20 - MAX 40): ");
                                                    input = Convert.ToInt32(ReadLine());
                                                }
                                                Clear();
                                                WriteLine("Working.....");

                                                if (Profile.taxReducer == true)
                                                {
                                                    extraFees = 250;

                                                    if (Profile.storeDiscount == true)
                                                    {
                                                        extraFees += 500;
                                                    }
                                                }

                                                Thread.Sleep(input * 100);
                                                payDetails = new(input, levelIndex, extraFees);
                                                jobDetails.UpdateProperties(payDetails);
                                                randomID = random.Next(100, 999);
                                                bankAccount.AddJob(payDetails, randomID, "Work Pay");
                                                weeksWorked++;
                                                weeksLeft--;
                                                Clear();

                                                if (weeksLeft == 0)
                                                {
                                                    if (levelIndex == 2)
                                                    {
                                                        WriteLine("Another 10 great weeks as a senior with us! Thank you!");
                                                    }
                                                    else
                                                    {
                                                        levelIndex++;
                                                        WriteLine($"CONGRATULATIONS! You were promoted to {payDetails.JobLevel[levelIndex]}!");
                                                        WriteLine("Your pay rate was increased and if applicable, an unique benefit was added for your role!");
                                                        WriteLine("Thank you for your time with us!");
                                                        WriteLine($"NOTE: Changes will be applied on next paycheck!");
                                                        WriteLine("");
                                                        weeksLeft = 10;
                                                    }
                                                }
                                                WriteLine("Keep up the hard work and you will be promoted!");
                                                WriteLine("");
                                                payDetails.DisplayPaycheck();
                                                WriteLine(bankAccount.DisplayBalance());
                                                input = 0; //resets value
                                                WriteLine("");
                                                WriteLine("Press ANY key to go back to menu");
                                                ReadKey();
                                                Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Clear();
                                                WriteLine("You can't work if you dont have a job!");
                                                Thread.Sleep(2000);
                                                Clear();
                                                break;
                                            }
                                        case 4:
                                            if (jobDetails.hasJob == true)
                                            {
                                                jobDetails.ResignJob(payDetails);
                                                if (jobDetails.hasResign == true)
                                                {
                                                    weeksWorked = 0;
                                                    weeksLeft = 10;
                                                    levelIndex = 0;
                                                }
                                            }
                                            else
                                            {
                                                Clear();
                                                WriteLine("You cannot do this because you don't have a job!");
                                            }
                                            break;
                                        case 5:
                                            breakFlag = false; //NEW! Escape a While(true) using a boolean!
                                            Clear();
                                            break;
                                    }
                                }
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
                                    ItemShop.PurchasingProduct(Profile, bankAccount, randomID, "Purchase");
                                    break;
                                }
                            case 6:
                                Clear();
                                if (bankAccount.TransactionID.Count < 1)
                                {
                                    WriteLine();
                                    BankStatement.ErrorMessageStatement();
                                    Thread.Sleep(5000);
                                    Clear();
                                    break;
                                }
                                else
                                {
                                    BankStatement.CreateStatement(bankAccount, Profile, DateOnly.FromDateTime(DateTime.Now));
                                    break;

                                }
                            case 7: //WILL WORK ON CONFIRMATION FEATURE SOON
                                Clear();
                                breakFlag = false;
                                break; // (Must be removed)

                            default:
                                {
                                    WriteLine("DEBUG: Invalid input");
                                    Clear();
                                    break;
                                }
                        }
                    }
                    break;
                case 3:
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
