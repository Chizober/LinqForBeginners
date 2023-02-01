using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqExamples linq = new LinqExamples();
            linq.linqExample1();
            linq.linqExample2();
            linq.linqExample3();
            linq.linqExample4();
            linq.linqExample5();
            linq.FetchEmployeesAndDepartments();
        }
    }
}
