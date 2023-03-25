using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForClasses_BankApp
{
    public class Withdrawl
    {
        public decimal TakeOut { get; set; }

        public Withdrawl(decimal takeOut) 
        {
            this.TakeOut = takeOut;
        }
    }
}
