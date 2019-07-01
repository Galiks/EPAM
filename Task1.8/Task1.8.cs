using System;
using System.Linq;

namespace Task1._8
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            NoPositiveMethod();
        }

        private static void NoPositiveMethod()
        {
            int[,,] array = new int[5, 5, 5];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = random.Next(-10, 10);
                    }
                }
            }

            foreach (var i in Enumerable.Range(0, array.GetLength(0)))
            {
                foreach (var j in Enumerable.Range(0, array.GetLength(1)))
                {
                    foreach (var k in Enumerable.Range(0, array.GetLength(2)))
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }

            foreach (var i in Enumerable.Range(0, array.GetLength(0)))
            {
                foreach (var j in Enumerable.Range(0, array.GetLength(1)))
                {
                    foreach (var k in Enumerable.Range(0, array.GetLength(2)))
                    {

                        Console.WriteLine(array[i, j, k]);

                    }
                }
            }
        }
    }
}
