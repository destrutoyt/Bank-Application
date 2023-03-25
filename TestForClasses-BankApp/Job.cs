using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForClasses_BankApp
{
    class Job : Bank
    {
        public decimal PayRate { get; set; }
        public string JobName { get; set; }
        public int HoursWorked { get; set; }
        public decimal Pay { get; set; }

        public Job(decimal PayRate, string jobName, int hoursW) : base(Name:"hi", Balance:0) 
        {
            this.PayRate = PayRate;
            this.JobName = jobName;
            this.HoursWorked = hoursW;
        }

        public void JobInfo()
        {
            Pay = PayRate * HoursWorked;
            Console.WriteLine($"You worked at {JobName} with a PayRate of ${PayRate}/h.You worked {HoursWorked} hours and got paid ${Pay}");
        }
    }
}