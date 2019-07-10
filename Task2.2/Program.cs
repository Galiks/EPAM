using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(5, 4, 3);
            Console.WriteLine(triangle.Area);
            Console.WriteLine(triangle.Perimeter);
            Console.ReadKey();
        }
    }
}
