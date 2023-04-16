using TestForClasses_BankApp;
using static System.Console;



// THIS IS A PROGRAM TO TEST CLASSES FOR FUTURE USES. THE PRACTICE HERE IS APPLIED TO THE BANK APPLICATION PROGRAM!
// IT IS ALSO USE TO TEST NEW FEATURES

Bank bank = new Bank("Test", 500);
Shopping? shop = null;
Random random = new Random();
int transactionRandom = random.Next(99999); //Creates a random number for account number

string productName = "test";
int index = 0;

Write("Product name: ");
productName = Convert.ToString(ReadLine());
Write("Number: ");
index = Convert.ToInt32(ReadLine());

shop = new Shopping(index);
shop.CanBuy(productName, bank, transactionRandom);

WriteLine(bank.Transaction());