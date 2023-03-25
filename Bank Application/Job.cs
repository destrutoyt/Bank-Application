using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application
{
    public class Job
    {
        public decimal PayRate { get; private set; }
        public int Hours { get; private set; }
        public decimal PayTotal { get; set; }

        public Job(decimal payRate, int hours)
        {
            PayRate = payRate;
            Hours = hours;
        }

        public void DisplayPaycheck()
        {
            PayTotal = PayRate * Hours;
            Console.WriteLine($"Pay Per Hour: {PayRate:C}/h");
            Console.WriteLine($"Hours Worked: {Hours}H");
            Console.WriteLine($"Total Pay: {PayTotal:C}");
        }
    }
}
