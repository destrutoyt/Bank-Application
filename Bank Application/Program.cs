using Bank_Application;
using System.Security.Principal;
using static System.Console;


class RunProgram
{
    static List<CreateAccount> accounts = new List<CreateAccount>();

    static void Main(string[] args)
    {
        string user = "none";
        string pass = "none";
        string passRule = "~!@#$%^&*()_+=-`/*-+/?.>,<';][}{:"; ///NOT ALLOWED
        string name = "none";
        string log_user = "none";
        string log_pass = "none";
        double balance = 0;
        bool goBack = false;
        bool goBack2 = false;
        int selection1;

        while (true) //GOES BACK TO MENU IF TRUE
        {
            WriteLine("Welcome to your Online Bank");
            WriteLine("\n");

            WriteLine("== MENU ==");
            WriteLine("1. Registration");
            WriteLine("2. Log In");
            WriteLine("3. Admin Access");
            WriteLine("4. Exit");
            Write("Enter your option (ONLY NUMBERS ALLOWED): ");
            int selection = Convert.ToInt16(ReadLine());

            switch (selection)
            {
                case 1: //REGISTRATION
                    WriteLine("So we have a new member on our ship?!");
                    WriteLine("However, to join us, you must finish a required registration!");
                    WriteLine("Your security is our TOP PRIORITY, but you need to help us out!");
                    WriteLine("Enough of the boring text! Let's get you to the registration!");
                    WriteLine("\n");
                    WriteLine("Let's start off with your new and awesome username!");
                    Write("Write your username for log-in purposes: ");
                    user = Convert.ToString(ReadLine());

                    WriteLine("\n");
                    WriteLine("Awesome! Now let's get you to the most important part!");
                    WriteLine("Your password is important to keep you safe, so we decided to add some requirements for your safety");

                    WriteLine("REQUIREMENTS:\n1. Must be at least 5 characters long\n2. Cannot be your username\n" +
                        "Now, I will let your create your password!\n");

                    Write("Create your password (CASE SENSITIVE): ");
                    pass = Convert.ToString(ReadLine());

                    while (pass == user || pass.Length < 5)
                    {
                        WriteLine("Ups! you did not follow our requirements :(");
                        Write("Try again, create a password: ");
                        pass = Convert.ToString(ReadLine());
                    }
                    WriteLine("Great password! Please do not forget it!\n");
                    WriteLine("\nNow, we need your full name or at least your first name for legal purposes");
                    WriteLine("Don't worry about capitalization! Our system will do it for you!\nHowever, your name must not contain numbers or special characters!\n");
                    Write("Insert your Full Name or First Name: ");
                    name = Convert.ToString(ReadLine());

                    while (name == user || pass.Length > 100 || pass == passRule)
                    {
                        WriteLine("Ups! you did not insert a valid name");
                        Write("Try again, Insert your Full Name or First Name: ");
                        pass = Convert.ToString(ReadLine());
                    }

                    WriteLine("\n");
                    WriteLine("AMAZING! Now, let us do some backend work in order to pull out your bank account!");
                    WriteLine("\n");

                    Random random = new Random();
                    int customerid = random.Next(9999999); //Creates a random number for customer ID
                    int bank_account = random.Next(99999); //Creates a random number for account number
                    balance = 200;
                    CreateAccount Profile = new CreateAccount(new int[] { customerid }, new string[] { user }, new string[] { pass }, new string[] { name }, balance, bank_account); //Calls constructor
                    Profile.Balance = balance;
                    accounts.Add(Profile);
                    WriteLine(accounts.ToString());

                    Clear();
                    Profile.Details(); //Calls Details Class

                    WriteLine("\n");
                    WriteLine($"Welcome To The Ship Mr/Ms {name}!");
                    WriteLine("You can now log-in into your bank account and guess what! We just gave you $200!");
                    goBack = true;
                    break;

                case 2:
                    WriteLine("LOG-IN\n");
                    Write("Username: ");
                    log_user = ReadLine();
                    Write("Password: ");
                    log_pass = Convert.ToString(ReadLine());
                    WriteLine("\n");

                    while (log_user != user || log_pass != pass)
                    {
                        WriteLine("It looks like either you are not registered or you inserted the wrong username/password");
                        Write("Username: ");
                        log_user = ReadLine();
                        Write("Password: ");
                        log_pass = Convert.ToString(ReadLine());
                        WriteLine("\n");
                    }

                    while (true)
                    {
                        WriteLine("Welcome Back {0}", name);
                        WriteLine($"Bank Account                   Wallet: NOT AVAILABLE YET Balance: ${balance}");
                        WriteLine("MENU");
                        WriteLine("1. Deposit");
                        Write("Selection (MUST BE A NUMBER): ");
                        selection = Convert.ToInt32(ReadLine());

                        switch (selection)
                        {
                            case 1:
                                Test(Profile.Balance);
                                goBack2 = true;
                                break;

                            case 2:
                                Test(balance);
                                break;
                        }

                    }
                default:
                    break;
            }
        }
    static void Test(double balance)
        {
            Job paycheck = new Job(balance);
            WriteLine("You worked really hard this week!");
            WriteLine("Keep up the amazing job and you might get a raise!");
            WriteLine($"You were paid ${paycheck.salary} and your new balance is $" + paycheck.PayCheck()); //ERROR FIXED 3/6/2023
        }
    }
}
