using Bank_Application;
using System.Security.Principal;
using System.Text.RegularExpressions;
using static System.Console;

//REGISTRATION / LOGIN
string user = "none";
string pass = "none";
string passRule = "~!@#$%^&*()_+=-`/*-+/?.>,<';][}{:"; ///NOT ALLOWED
string name = "none";
string log_user = "none";
string log_pass = "none";
bool authorized = false; //FOR FUTURE REFERENCES

//JOB
decimal payRate = 12;

//OBJECTS
var balance = new BankAccount(200m);
var payment = new Job(0 , 0);

//OTHERS
bool goBack = false;

StartOfProgram:
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
    CreateAccount Profile = null;
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

            while (name == user || name.Length > 100 || !Regex.IsMatch(name, "^[a-zA-Z\\s]*$"))
            {
                WriteLine("Ups! you did not insert a valid name");
                Write("Try again, Insert your Full Name or First Name: ");
                pass = Convert.ToString(ReadLine());
            }

            WriteLine("\n");
            WriteLine("AMAZING! Now, let us do some backend work in order to pull out your bank account!");
            WriteLine("\n");

            Random random = new Random();
            int bank_account = random.Next(99999); //Creates a random number for account number
            Profile = new CreateAccount(user, pass, name, bank_account); //Calls constructor

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
                authorized= false;
            }
            authorized= true;
            
            while (true)
            {
                WriteLine(" = Welcome Back {0} = ", name);
                WriteLine("MENU");
                WriteLine("1. Account Information"); //NOT FINISHED
                WriteLine("2. Work"); //WORK ON RETURNING UPDATED BALANCE VALUE
                WriteLine("3. Log-Off"); //FINISHED (MIGHT ADD CONDITIONS FOR DOUBLE CONFIRMATION)
                Write("Selection (MUST BE A NUMBER): ");
                selection = Convert.ToInt32(ReadLine());

                switch (selection)
                {
                    case 1:
                        if (Profile != null && Profile.AccountNumber != null)
                        {
                            Console.WriteLine("Balance: {0}", Profile.AccountNumber);
                        }
                        else
                        {
                            Console.WriteLine("Profile or AccountInformation is null.");
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            WriteLine("");
                            WriteLine("Time to get some money!");
                            WriteLine($"Your current job pays you ${payRate}");
                            Write("How many hours would you like to work per week? (MAX 40): ");
                            WriteLine("");

                            int input = Convert.ToInt32(ReadLine());
                            payment = new Job(payRate, input);
                            balance.AddJob(payment.PayT);

                            while (input < 0 || input > 40)
                            {
                                WriteLine("Wrong Input");
                                Write("How many hours would you like to work per week? (MAX 40): ");
                                input = Convert.ToInt32(ReadLine());
                                payment = new Job(payRate, input);
                                balance.AddJob(payment.PayT);
                            }

                            balance.AddJob(12);
                            WriteLine("");
                            WriteLine("You worked really hard this week!");
                            WriteLine("Keep up the amazing job and you might get a raise!");
                            WriteLine($"DETAILS:"); //ERROR FIXED 3/6/2023
                            payment.DisplayPayment();
                            WriteLine(balance.DisplayBalance());
                            WriteLine("");
                            break;
                        }
                        break;
                    case 3:
                        goto StartOfProgram; //NEW !!!
                        break;
                }
            }
    }
    WriteLine("code was succesfully finished. If you see this, it means there were no fatal errors." +
        "However, logic errors are not tested which means that their success must be verified manually.");
}
//END OF CODE