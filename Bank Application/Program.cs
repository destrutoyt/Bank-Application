using static System.Console;

class CreateAccount //MUST FINISH BEFORE CONTINUING WITH ANOTHER CLASS
{
    string username;
    string password;
    string customer_name;
    int customerID; //MUST BE RANDOM

    public CreateAccount(string username, string password, string customer_name, int customer_id) //CONSTRUCTOR
    {
        this.username = username;
        this.password = password;
        this.customer_name = customer_name;
        this.customerID = customer_id;
    }
    public void Details() //MUST BE DEVELOP
    {
        WriteLine("= = = = = = = = = = = = =");
        Console.WriteLine("PROFILE DETAILS");
        Console.WriteLine($"User: {username}");
        Console.WriteLine($"Name: {customer_name}");
        Console.WriteLine($"ID: {customerID}");
        WriteLine("= = = = = = = = = = = = =");
    }
}

class BankAccount
{
    double balance;
    int account_number;
}

class RunProgram
{
    static void Main(string[] args)
    {
        bool goBack = false;
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
                    string user;
                    string pass;
                    string passRule = "~!@#$%^&*()_+=-`/*-+/?.>,<';][}{:"; ///NOT ALLOWED
                    string name;

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
                        "Now, I will let your create your password!");

                    Write("Create your password (CASE SENSITIVE): ");
                    pass = Convert.ToString(ReadLine());

                    while (pass == user || pass.Length < 5)
                    {
                        WriteLine("Ups! you did not follow our requirements :(");
                        Write("Try again, create a password: ");
                        pass = Convert.ToString(ReadLine());
                    }
                    WriteLine("Great password! Please do not forget it!");
                    WriteLine("\nNow, we need your full name or at least your first name for legal purposes");
                    WriteLine("Don't worry about capitalization! Our system will do it for you!\nHowever, your name must not contain numbers or special characters!");
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
                    CreateAccount Profile = new CreateAccount(user, pass, name, customerid); //Calls constructor

                    Clear();
                    Profile.Details(); //Calls Details Class

                    WriteLine("\n");
                    WriteLine($"Welcome To The Ship Mr/Ms {name}!");
                    WriteLine("You can now log-in into your bank account and guess what! We just gave you $200!");
                    Clear();
                    goBack = true;
                    break;

                case 2:
                    WriteLine("Test 2");
                    break;
                case 3:
                    WriteLine("Test 3");
                    break;
                default:
                    WriteLine("Exiting Program");
                    break;
            }
        }
    }
}