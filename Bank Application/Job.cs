using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application
{
    public class Job
    {
        public decimal PayH { get; private set; }
        public int Hours { get; private set; }
        public decimal PayT { get; set; }

        public Job(decimal payH, int hours)
        {
            PayH = payH;
            Hours = hours;
        }

        public void DisplayPayment()
        {
            PayT = PayH * Hours;
            Console.WriteLine($"Pay Per Hour {PayH:C}!");
            Console.WriteLine($"Hours Worked {Hours:C}!");
            Console.WriteLine($"Total Pay: {PayT:C}!");
        }
    }
}

