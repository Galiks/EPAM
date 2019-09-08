using System;
using System.Collections.Generic;
using System.Text;

namespace Task0
{
    public static class Task2
    {
        public static void TaskZerpPointTwo()
        {
            Console.Write("Enter a unsigned number: ");
            string number = Console.ReadLine();
            if (int.TryParse(number, out int realNumber))
            {
                if (realNumber > 0)
                {
                    if (IsSimpleNumber(realNumber))
                    {
                        Console.WriteLine($"{realNumber} is simple");
                    }
                    else
                    {
                        Console.WriteLine($"{realNumber} is not simple");
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

        private static bool IsSimpleNumber(int realNumber)
        {
            for (int i = 2; i <= Math.Sqrt(realNumber); i++)
            {
                if (realNumber % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
