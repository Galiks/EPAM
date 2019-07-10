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
            Round round = new Round(5, 5, -1);
            Console.WriteLine(round.GetArea);
            Console.WriteLine(round.GetCircumference);
            Console.WriteLine(round.Center);
            Console.WriteLine(round.Radius);
            Console.ReadKey();
        }
    }
}
