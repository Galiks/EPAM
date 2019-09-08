using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public static class Task2
    {
        public static void PrintTriangle()
        {
            Console.Write("Enter a number: ");
            string number = Console.ReadLine();
            if (int.TryParse(number, out int realNumber))
            {
                if (realNumber > 0)
                {
                    for (int i = 0; i <= realNumber; i++)
                    {

                        Console.WriteLine(new string('*', i));
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect format of number");
                }
            }
            else
            {
                Console.WriteLine("Incorrect format of number");
            }
        }
    }
}
