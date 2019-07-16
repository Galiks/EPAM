using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString myString = new MyString(new char[] { 'H', 'E', 'L', 'L', 'O' });
            Console.WriteLine(myString);
            string line = "HELLO";
            Console.ReadKey();
        }
    }
}
