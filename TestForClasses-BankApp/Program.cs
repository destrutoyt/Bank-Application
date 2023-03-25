using TestForClasses_BankApp;
using static System.Console;



// THIS IS A PROGRAM TO TEST CLASSES FOR FUTURE USES. THE PRACTICE HERE IS APPLIED TO THE BANK APPLICATION PROGRAM!
// IT IS ALSO USE TO TEST NEW FEATURES

string name = "";
string job = "";
decimal payRate = 0;
decimal withdrawl = 0;
int hours = 0;

Job test; //CALLING CLASSES
Withdrawl takeOut;

Write("What's your name: ");
name = ReadLine();
Write("Name of the job: ");
job = ReadLine();
Write("Pay rate per hour: ");
payRate = Convert.ToDecimal(ReadLine());
Write("How many hours you work: ");
hours = Convert.ToInt32(ReadLine());

Write("Num:");
int num = Convert.ToInt32(ReadLine());

test = new Job(payRate, job, hours);  //INITIATE CLASS
test.JobInfo();
test.ReturnNewBalance(test);

Write("How much you want to take out?: ");
withdrawl = Convert.ToDecimal(ReadLine());
takeOut = new Withdrawl(withdrawl);
test.WithdrawlMoney(takeOut);
