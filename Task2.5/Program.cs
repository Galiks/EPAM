using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("программист", new DateTime(2019, 09, 01),
                "Pavel", "Turchenkov", "Alexandrovich", new DateTime(1996, 12, 04));
            Console.WriteLine(employee);
            Console.ReadKey();
        }
    }
}
