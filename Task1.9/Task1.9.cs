using System;

namespace Task1._9
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            NonNegativeSum();
        }

        private static void NonNegativeSum()
        {
            int[] array = new int[10];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    sum += array[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
