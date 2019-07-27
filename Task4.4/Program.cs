using System;

namespace Task4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 5, 9, 0, 3, 6, 84, 4 };

            Console.WriteLine(array.GetSumOfNumbersWithLinq());

            Console.WriteLine(array.GetSumOfNumbers());

            Console.ReadKey();
        }
    }
}
