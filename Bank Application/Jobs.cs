using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Bank_Application
{
    public class Jobs
    {
        public bool hasJob = false;
        public bool hasResign = false;
        int inputnum;
        string inputString;

        public string jobName = "Unemployed";
        public decimal setPayRate, setPayRaise, setBonus;
        decimal setReducedTax;
        public void JobSelection(PaySystem addPayData)
        {
            inputnum = 3;
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
                SoftwareDetails();
                Write("Would you like to take this job? (Y / N): ");
                inputString = ReadLine().ToUpper();
                if (inputString == "Y")
                {
                    Clear();
                    WriteLine("Applying to Software Engineer...");
                    Thread.Sleep(2000);
                    setPayRate = 25;
                    setBonus = 100;
                    setPayRaise = 45;
                    setReducedTax = 0.025m;
                    jobName = "Software Engineer";
                    WriteLine("YOU ARE NOW WORKING AS A SOFTWARE ENGINEER!");
                    WriteLine("Press ANY key to continue");
                    ReadKey();
                    hasJob = true;
                }
                else
                {
                    Thread.Sleep(2000);
                    WriteLine("Going back to main menu..");
                    Clear();
                }
            }
            if (inputnum == 1)
            {
                GraphicDetails();
                Write("Would you like to take this job? (Y / N): ");
                inputString = ReadLine().ToUpper();
                if (inputString == "Y")
                {
                    Clear();
                    WriteLine("Applying to Graphic Designer...");
                    Thread.Sleep(2000);
                    setPayRate = 15;
                    setBonus = 150;
                    setPayRaise = 30;
                    setReducedTax = 0.025m;
                    jobName = "Graphic Designer";
                    hasJob = true;
                    WriteLine("YOU ARE NOW WORKING AS A GRAPHIC DESIGNER");
                    WriteLine("Press ANY key to continue");
                    ReadKey();
                }
                else
                {
                    Thread.Sleep(2000);
                    WriteLine("Going back to main menu..");
                    Clear();
                }
            }
            if (inputnum == 2)
            {
                LawyerDetails();
                Write("Would you like to take this job? (Y / N): ");
                inputString = ReadLine().ToUpper();
                if (inputString == "Y")
                {
                    Clear();
                    WriteLine("Applying to Lawyer...");
                    Thread.Sleep(2000);
                    setPayRate = 30;
                    setBonus = 50;
                    setPayRaise = 35;
                    setReducedTax = 0.010m;
                    jobName = "Lawyer";
                    hasJob = true;
                    WriteLine("YOU ARE NOW WORKING AS A LAWYER!");
                    WriteLine("Press ANY key to continue");
                    ReadKey();
                }
                else
                {
                    Thread.Sleep(2000);
                    WriteLine("Going back to main menu..");
                    Clear();
                }
            }
            else
            {
                return;
            }
        }
        public void JobDashboard(PaySystem jobData, int jobLevel, int weeksLeft)
        {
            if (jobLevel == 2)
            {
                WriteLine($"= {jobName} Dashboard =");
                WriteLine("");
                WriteLine($"Level: {jobData.JobLevel[jobLevel]}");
                WriteLine($"Current Pay Rate: {setPayRaise:C}/h");
                WriteLine($"Bonus for being a Senior: {setBonus}");
                WriteLine("");
                WriteLine("Press ANY key to continue!");
                ReadKey();
                Clear();
            }
            else if (jobLevel == 1)
            {
                WriteLine($"= {jobName} Dashboard =");
                WriteLine("");
                WriteLine($"Level: {jobData.JobLevel[jobLevel]}");
                WriteLine($"Current Pay Rate: {setPayRaise:C}/h");
                WriteLine($"Weeks lefts for next level: {weeksLeft}");
                WriteLine("");
                WriteLine("Press ANY key to continue!");
                ReadKey();
                Clear();
            }
            else
            {
                WriteLine($"= {jobName} Dashboard =");
                WriteLine("");
                WriteLine($"Level: {jobData.JobLevel[jobLevel]}");
                WriteLine($"Current Pay Rate: {setPayRate:C}/h");
                WriteLine($"Weeks lefts for next level: {weeksLeft}");
                WriteLine("");
                WriteLine("Press ANY key to continue!");
                ReadKey();
                Clear();
            }
        }

        public void UpdateProperties(PaySystem addPayData)
        {
            addPayData.PayRate = setPayRate;
            addPayData.Bonus = setBonus;
            addPayData.PayRaise = setPayRaise;
            addPayData.ReducedTax = setReducedTax;
            addPayData.JobName = jobName;
        }
        public void ResignJob(PaySystem jobData)
        {
            Clear();
            WriteLine("= ATTENTION =");
            WriteLine("You are about to quit your job!");
            WriteLine($"Resignation means you will lose ALL progress made in the {jobData.JobName} position.");
            WriteLine("It includes experience level, bonuses, benefits, and current pay rate");
            WriteLine("In addition, it will leave you unemployed and you won't get any income unless you pick another job!");
            Write("Are you sure you want to proceed? (Y to continue or ANY other letter to exit this menu): ");
            inputString = ReadLine().ToUpper();

            if (inputString == "Y")
            {
                Clear();
                WriteLine("Resigning job...");
                Thread.Sleep(2000);
                setPayRate = 0;
                setBonus = 0;
                setPayRaise = 0;
                setReducedTax = 0;
                jobName = "Unemployed";
                hasJob = false;
                hasResign = true;
                WriteLine("You resigned to your position!\n" + "Press ANY key to continue!");
                ReadKey();
                Clear();
            }
            else
            {
                WriteLine("Exiting this menu...");
                Thread.Sleep(2000);
                Clear();
            }
        }

        void SoftwareDetails()
        {
            Clear();
            WriteLine("= INFORMATION ABOUT SOFTWARE ENGINEER =\n" + "Your starting pay rate will be $25/h\n" + "Juniors will get a raise of $20 in their pay rate\n"
                + "Seniors will benefit from $100 bonus EACH paycheck (Bonus will not be subject to tax deduction)\n");
        }
        void GraphicDetails()
        {
            Clear();
            WriteLine("= INFORMATION ABOUT GRAPHIC DESIGNER =\n" + "Your starting pay rate will be $15/h\n" + "Juniors will get a raise of $15 in their pay rate\n"
                + "Seniors will benefit from $150 bonus EACH paycheck (Bonus will not be subject to tax deduction)");
        }
        void LawyerDetails()
        {
            Clear();
            WriteLine("= INFORMATION ABOUT LAWYER =\n" + "Your starting pay rate will be $30/h\n" + "Juniors will get a raise of $10 in their pay rate and federal taxes will be reduced to 1%\n"
                + "Seniors will benefit from $50 bonus EACH paycheck (Bonus will not be subject to tax deduction)");
        }

    }
}