using TestForClasses_BankApp;
using static System.Console;



// THIS IS A PROGRAM TO TEST CLASSES FOR FUTURE USES. THE PRACTICE HERE IS APPLIED TO THE BANK APPLICATION PROGRAM!
// IT IS ALSO USE TO TEST NEW FEATURES

Paychecks? paychecks = null;
Jobs shop = new Jobs();

int numInput;
shop.JobSelection(paychecks);
while (true)
{
    Write("Hours: ");
    numInput = Convert.ToInt32(ReadLine());

    paychecks = new(numInput, 1, 0);
    shop.Work(paychecks);
    paychecks.DisplayPaycheck();
}