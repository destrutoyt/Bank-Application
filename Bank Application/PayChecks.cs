using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Bank_Application
{
    public class PayChecks
    {
        int jobLevelIndex;
        int hours;
        decimal bonus;
        decimal grossPay;
        decimal federalTax = 0.025m; //Can be changed
        decimal taxAmount;

        public PayChecks(int hours, int jobLevel, decimal upgradeFees)
        {
            this.hours = hours;
            jobLevelIndex = jobLevel;
            UpgradeFees = upgradeFees;
        }
        public void DisplayPaycheck()
        {
            if (jobLevelIndex == 1)
            {
                PayRate = PayRaise;
                federalTax = ReducedTax;
            }
            if (jobLevelIndex == 2)
            {
                PayRate = PayRaise;
                federalTax = ReducedTax;
                bonus = Bonus;
            }

            grossPay = PayRate * hours;
            taxAmount = grossPay * (decimal)federalTax;
            NetPay = grossPay + bonus - taxAmount - UpgradeFees;

            WriteLine("= PAYCHECK DETAILS =");
            WriteLine("");
            WriteLine("= JOB DETAILS =");
            WriteLine($"Job Name: {JobName}");
            WriteLine($"Level: {JobLevel[jobLevelIndex]}");
            WriteLine("");
            WriteLine("= PAY & HOURS =");
            WriteLine($"Hours Worked: {this.hours}H");
            WriteLine($"Pay Per Hour: {PayRate}/h");
            WriteLine($"Gross Pay: {grossPay:C}");
            WriteLine("");
            WriteLine("= OTHER FEES =");
            WriteLine($"Upgrade Fees: {UpgradeFees:C}");
            WriteLine($"Federal Tax ({federalTax.ToString("P2")}): {taxAmount}");
            WriteLine("");
            WriteLine("= TAKE HOME =");
            WriteLine($"Net Pay: {NetPay:C}");
        }
        public decimal PayRate { get; set; }
        public decimal PayRaise { get; set; }
        public decimal Bonus { get; set; }
        public decimal ReducedTax { get; set; }
        public string JobName = "test";
        public string[] JobLevel = { "Associate", "Junior", "Senior" };
        private decimal UpgradeFees { get; set; }
        public decimal NetPay { get; set; }
    }
}