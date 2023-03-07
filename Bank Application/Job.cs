using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application
{
    public class Job
    {
        public double salary = 150.0;
        double balance;

        public Job(double balance)
        {
            this.balance = +balance;
        }

        public double PayCheck()
        {
            return salary + balance; //FIXED
        }
    }
}
