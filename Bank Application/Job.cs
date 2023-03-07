using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application
{
    public class Job : CreateAccount
    {
        public double salary = 150.0;

        public Job(string user, string password, string name, double balance, int account_number) : base(user, password, name, balance, account_number) { }

        public void PayCheck(double salary)
        {
           balance =+ salary; //FIXED
        }
    }
}
