using Bank_Application;
using System.Security.Principal;
using System.Text.RegularExpressions;
using static System.Console;

class Program
{ 
    static public void Main(String[] args)
    {
        // TEST RELEASE by Miguel Angel Garces Lenis (ReWorked Version 1.0_TEST)

        //REGISTRATION / LOGIN
        string user = "none";
        string pass = "none";
        string firstName = "none";
        string loginUser = "none";
        string loginPass = "none";

        //JOB
        decimal payRate = 12;
        int weeksWorked = 0;
        decimal payRaise = 2;

        //OTHERS
        Random random = new Random();
        int bank_account = random.Next(9999999); //Creates a random number for account number
        int selection = 0; //MENU SELECTION
        int input = 0; //MENU 2 SELECTION
        string fileLocation = "";

        //OBJECTS
        var bankAccount = new BankAccount(200m); //START WITH $200 BALANCE BY CREATING NEW ACCOUNT
        var jobDetails = new Job(0, 0);
        Account? Profile = null; ; //initiate a null object QUESTION MARK IS REQUIRED FOR NULLABLE TYPES
        CreateFile BankStatement = null;

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
                    Profile = new Account(user, pass, firstName, bank_account); //Calls constructor and creates a new object
                    WriteLine("Creating Account..");
                    Thread.Sleep(1000); //DELAY 1 SECOND

                    Clear();
                    Profile.Details(); //Calls Details Class
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
                        loginPass = loginPass = ReadLine();
                        WriteLine("\n");
                    }
                    Clear();
                    while (true)
                    {
                        WriteLine(" = Welcome {0} = ", firstName);
                        WriteLine("MENU");
                        WriteLine("1. Account Information");
                        WriteLine("2. Work");
                        WriteLine("3. Get Statement"); //WORKING ON IT
                        WriteLine("4. Log-Off"); //goto statement must go
                        Write("Selection (MUST BE A NUMBER): ");
                        selection = Convert.ToInt32(ReadLine());
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
                                bankAccount.AddJob(jobDetails);
                                weeksWorked++;
                                Clear();

                                if (weeksWorked % 5 == 0)
                                {
                                    WriteLine($"CONGRATULATIONS! You were given a raise of +${payRaise} for your hourly payrate");
                                    payRate += payRaise;
                                    WriteLine($"New Rate Available On Next Paycheck: ${payRate}/h");
                                }
                                WriteLine("You worked really hard this week!");
                                WriteLine("Keep up the amazing job and you might get a raise!");
                                WriteLine("");
                                WriteLine($"DETAILS:"); //ERROR FIXED 3/6/2023
                                jobDetails.DisplayPaycheck();
                                WriteLine(bankAccount.DisplayBalance(jobDetails.PayTotal));
                                WriteLine("");
                                WriteLine("Press ANY key to go back to menu");
                                ReadKey();
                                Clear();
                                break;
                            case 3:
                                Write("What is the exact User being used right now in your computer?:");
                                fileLocation = ReadLine();

                                BankStatement = new CreateFile(fileLocation, 0000);
                                if (BankStatement == null || Profile == null)
                                {
                                    BankStatement.ErrorMessageForStatement();
                                    ReadKey();
                                }
                                else
                                {
                                    BankStatement.CreateStatement(bankAccount);
                                    ReadKey();
                                }
                                break;

                            case 4: //WILL WORK ON CONFIRMATION FEATURE SOON
                                goto StartOfProgram; //NEW !!! (Must be removed)

                            default:
                                {
                                    WriteLine("Invalid input");
                                    Clear();
                                    break;
                                }
                        }
                    }
                case 3:
                    WriteLine("ADMIN CONTROL COMING SOON");
                    break;

                default:
                    {
                        WriteLine("Invalid input");
                        Clear();
                        break;
                    }
            }
        }
    }
}
//END OF CODE