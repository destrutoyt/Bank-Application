using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace TestForClasses_BankApp
{
    public class Paychecks
    {
        int jobLevelIndex;
        int hours;
        public decimal PayRate { get; set; }

        public decimal bonus;
        decimal grossPay;
        double federalTax = 0.025; //Can be changed
        decimal taxAmount;
        decimal total;

        public Paychecks(int hours, int jobLevel, decimal upgradeFees)
        {
            this.hours = hours;
            jobLevelIndex = jobLevel;
            UpgradeFees = upgradeFees;
        }
        public void DisplayPaycheck()
        {
            if (jobLevelIndex == 1)
            {
                bonus = SetBonus;
            }

            grossPay = PayRate * hours;
            taxAmount = grossPay * (decimal)federalTax;
            NetPay = grossPay + bonus - taxAmount - UpgradeFees;
            total +=NetPay;

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
            WriteLine($"Federal Tax ({federalTax}): {taxAmount}");
            WriteLine("");
            WriteLine($"Net Pay: {NetPay:C}");
            WriteLine($"Total Balance: {total:C}");
        }
        public decimal SetPayRaise { get; set; }
        public decimal SetBonus { get; set; }
        public double SetReducedTax { get; set; }
        public decimal UpgradeFees { get; set; }
        public string JobName = "test";
        public string[] JobLevel = { "Associate", "Junior", "Senior" };
        public decimal NetPay { get; set; }
    }
}
