using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TestForClasses_BankApp
{
    public class Jobs
    {
        public bool hasJob = false;
        int inputnum;
        string inputString;

        string jobName;
        decimal salary1;
        decimal salary2;
        decimal salary3;

        public void JobSelection(Paychecks addPayData)
        {
            WriteLine("Welcome to your place of work!");
            WriteLine("You are currently unemployed, but don't worry, we got you!");
            WriteLine("We are hiring at one of the following positions: \n- Software Engineer\n- Graphic Designer\n- Lawyer");
            try
            {
                Write("Which job caught your attention? (0-2 or 3 to quit): ");
                inputnum = Convert.ToInt32(ReadLine());
            }
            catch
            {
                WriteLine("You inserted a non-numeric input!");
                Clear();
            }

            while (inputnum > 3 || inputnum < 0)
            {
                WriteLine("You must pick a number between 0 and 2 or 3 to quit");
                Write("Which job caught your attention?: ");
                inputnum = Convert.ToInt32(ReadLine());
            }

            if (inputnum == 0)
            {
                WriteLine("Software Developer");
                Write("Would you like to take this job? (Y / N): ");
                inputString = ReadLine().ToUpper();
                if (inputString == "Y")
                {
                    Clear();
                    WriteLine("Applying to Software Engineer...");
                    Thread.Sleep(2000);
                    salary1 = 25;
                    salary2 = 10;
                    salary3 = 20;
                    jobName = "Software Engineer";
                    WriteLine("YOU ARE NOW WORKING AS A SOFTWARE ENGINEER!");
                    WriteLine("Press ANY key to continue");
                    ReadKey();
                    hasJob = true;
                }
                else
                {
                    return;
                }
            }
        }

        public void Work(Paychecks addPayData)
        {
            addPayData.PayRate = salary1;
            addPayData.SetBonus = salary3;
            addPayData.SetPayRaise = salary2;
            addPayData.JobName = jobName;
        }
    }
}
