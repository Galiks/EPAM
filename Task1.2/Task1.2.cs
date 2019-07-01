using System;

namespace Task1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTriangle();
            Console.ReadKey();
        }

        private static void PrintTriangle()
        {
            Console.Write("Enter a number: ");
            string number = Console.ReadLine();
            if (Int32.TryParse(number, out int realNumber))
            {
                if (realNumber > 0)
                {
                    for (int i = 0; i <= realNumber; i++)
                    {

                        Console.WriteLine(new String('*', i));
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
