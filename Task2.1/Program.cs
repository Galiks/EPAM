using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle round = new Circle(5, 5, -1);
            Console.WriteLine(round.GetArea);
            Console.WriteLine(round.GetCircumference);
            Console.WriteLine(round.Center);
            Console.WriteLine(round.Radius);
            Console.ReadKey();
        }
    }
}
