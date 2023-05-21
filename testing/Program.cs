using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class Program
{
    static void Main(String[] args)
    {
        string fileLocation = @"c:\temp\usersTEST.txt";
        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("4. Update cash");
            Console.WriteLine("3. lOG oFF");

            string option = Console.ReadLine();
            Balance balance = new Balance(50);
            int addbalance = 50;
            switch (option)
            {
                case "1":
                    Register(fileLocation, balance);
                    break;

                case "2":
                    if (Login(fileLocation, balance))
                    {
                        Console.WriteLine("Login successful!");
                        Console.WriteLine($"Balance: {balance.BalanceUser:C}");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect username or password.");
                    }
                    break;
                case "4":
                    balance.AddMoney();
                    Console.WriteLine($"Cash updated. New Balance {balance.BalanceUser}");
                    break;

                case "3":
                    UpdateLine(fileLocation, 3, balance);
                    Thread.Sleep(1000);
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public class Balance
    {
        public int BalanceUser { get; set; }

        public Balance(int firstBalance)
        {
            this.BalanceUser = firstBalance;
        }

        public void AddMoney()
        {
            BalanceUser += 50;
        }
    }
    static void Register(string fileLocation, Balance balance)
    {
        if (!File.Exists(fileLocation))
        {
            Console.WriteLine($"LOG: {fileLocation} created!");
            File.Create(fileLocation).Close(); // Create the file if it doesn't exist
        }
        string[] lines = File.ReadAllLines(fileLocation);
        Console.WriteLine("Enter a username:");
        string username = Console.ReadLine();
        while (lines.Any(line => line.Split(',').Length >= 2 && line.Split(',')[1] == username))
        {
            Console.WriteLine("Username already taken.");
            Console.WriteLine("Enter a username:");
            username = Console.ReadLine();
        }

        Console.WriteLine("Enter a password:");
        string password = Console.ReadLine();

        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();

        while (lines.Any(line => line.Split(',').Length >= 2 && line.Split(',')[2] == name))
        {
            Console.WriteLine("Name already taken.");
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
        }

        string profile = $"{username},{password},{name},{balance.BalanceUser}";
        File.AppendAllText(fileLocation, profile + Environment.NewLine);

        Console.WriteLine("Registration successful!");
        Console.WriteLine($"Total Cash: {balance.BalanceUser:C}. Balance data is from {username}");
    }

    static bool Login(string fileLocation, Balance getCashData)
    {
        Console.WriteLine("Enter your username:");
        string username = Console.ReadLine();

        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine();

        string[] lines = File.ReadAllLines(fileLocation);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length >= 3 && parts[0] == username && parts[1] == password)
            {
                return true;
            }
        }

        return false;
    }
    static void UpdateLine(string fileLocation, int lineNumber, Balance newBalance)
    {
        // Read all lines from the file
        string[] lines = File.ReadAllLines(fileLocation);

        Console.WriteLine($"Total lines in file: {lines.Length}");

        // Check if the line number is within the valid range
        if (lineNumber >= 1 && lineNumber <= lines.Length)
        {
            // Update the desired line with the new balance
            string lineToUpdate = lines[lineNumber - 1];
            string[] parts = lineToUpdate.Split(',');

            // Assuming the balance is the last part of the line
            if (parts.Length >= 4)
            {
                parts[3] = newBalance.BalanceUser.ToString(); // Assuming Balance class overrides ToString()

                lineToUpdate = string.Join(",", parts);
                lines[lineNumber - 1] = lineToUpdate;

                // Write the updated content back to the file
                File.WriteAllLines(fileLocation, lines);

                Console.WriteLine("Line updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid line format.");
            }
        }
        else
        {
            Console.WriteLine("Invalid line number.");
        }
    }
}
