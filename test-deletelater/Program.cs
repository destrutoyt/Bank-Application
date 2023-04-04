using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Transactions;
using static System.Console;

Random a = new Random(); // replace from new Random(DateTime.Now.Ticks.GetHashCode());
                                // Since similar code is done in default constructor internally
List<int> randomList = new List<int>();
int MyNumber = 0;

void NewNumber()
{
    MyNumber = a.Next(0, 10);
    if (!randomList.Contains(MyNumber))
        randomList.Add(MyNumber);
}