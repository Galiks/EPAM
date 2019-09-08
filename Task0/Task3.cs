using System;
using System.Collections.Generic;
using System.Text;

namespace Task0
{
    public static class Task3
    {
        public static void TaskZeroPointThree()
        {
            Console.Write("Enter a unsigned odd number: ");
            string number = Console.ReadLine();
            if (int.TryParse(number, out int realNumber))
            {
                if (realNumber > 0 && realNumber % 2 != 0)
                {
                    int centerOfSquare = realNumber / 2 + 1;
                    for (int i = 0; i < realNumber; i++)
                    {
                        if (i == centerOfSquare - 1)
                        {
                            string side = new string('*', centerOfSquare - 1);
                            Console.WriteLine($"{side} {side}");
                        }
                        else
                        {
                            Console.WriteLine(new string('*', realNumber));
                        }
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
