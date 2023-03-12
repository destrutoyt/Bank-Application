while (true)
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1. View balance");
    Console.WriteLine("2. Add money");
    Console.WriteLine("3. Pay");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("TEST");
            break;

        case "2":
            while (true)
            {
                Console.WriteLine("Enter amount to add (0 to quit): ");
                input = Console.ReadLine();
                if (!decimal.TryParse(input, out var amount))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                if (amount == 0)
                {
                    break; // exit the inner loop and return to the outer switch statement
                }

                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add to checking account");
                Console.WriteLine("2. Add to savings account");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("TEST");
                        break;

                    case "2":
                        Console.WriteLine("TEST");
                        break;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }

            }
            break;

        case "3":
            while (true)
            {
                Console.WriteLine("Enter amount to pay (0 to quit): ");
                input = Console.ReadLine();
                if (!decimal.TryParse(input, out var payment))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                if (payment == 0)
                {
                    break; // exit the inner loop and return to the outer switch statement
                }

                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Pay from checking account");
                Console.WriteLine("2. Pay from savings account");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("TEST");
                        break;

                    case "2":
                        Console.WriteLine("TEST");
                        break;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
            break;

        default:
            Console.WriteLine("Invalid input.");
            break;
    }
}