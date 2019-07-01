using System;

namespace Task1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void GetSumOfNumbers()
        {
            int sumOfNumbers = 0;
            for (int i = 0; i < 1001; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sumOfNumbers += i;
                }
            }
            Console.WriteLine(sumOfNumbers);
        }
    }
}
