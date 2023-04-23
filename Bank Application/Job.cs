using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Bank_Application
{
    public class Job
    {
        public decimal PayRate { get; private set; }
        public int Hours { get; private set; }
        public decimal PayTotal { get; set; }
        public decimal UpgradeFees { get; set; }

        public Job(decimal payRate, int hours, decimal upgradeFees)
        {
            PayRate = payRate;
            Hours = hours;
            UpgradeFees = upgradeFees;
        }

        public void DisplayPaycheck()
        {
            PayTotal = PayRate * Hours - UpgradeFees;
            WriteLine("= PAYCHECK DETAILS =");
            WriteLine($"Hours Worked: {Hours}H");
            WriteLine($"Pay Per Hour: {PayRate:C}/h");
            WriteLine($"Upgrade Fees: {UpgradeFees:C}");
            WriteLine($"Total Pay: {PayTotal:C}");
        }
    }
}