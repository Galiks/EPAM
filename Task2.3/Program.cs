using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Ivan", "Ivanov", "Ivanovich", new DateTime(1996, 12, 4));
            Console.WriteLine(user);
            Console.ReadKey();
        }
    }
}
