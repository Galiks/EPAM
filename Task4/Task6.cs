using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4
{
    public static class Task6
    {
        private delegate bool IsPositiveNumberDelegate(int item);

        public static void MainFunc()
        {
            int[] array = new int[] { 1, 2, -5, -7, 0, 3, -10, 4 };

            Console.WriteLine("Usual Method:");
            PrintPositiveNumber(array);
            Console.WriteLine();

            Console.WriteLine("Method with delegate:");
            PrintPositiveNumberViaDelegate(array, IsPositiveNumber);
            Console.WriteLine();

            Console.WriteLine("Method with anonymous delegate:");
            IsPositiveNumberDelegate isPositiveNumberAnonymous = delegate (int item)
            {
                return item >= 0;
            };
            PrintPositiveNumberViaAnonymousDelegate(array, isPositiveNumberAnonymous);
            Console.WriteLine();

            Console.WriteLine("Method with Lambda:");
            PrintPositiveNumberViaDelegate(array, item => item >= 0);
            Console.WriteLine();

            Console.WriteLine("Method with Linq:");
            PrintPostiveNumberViaLinq(array);
            Console.WriteLine();

            Console.ReadKey();
        }

        public static void PrintPositiveNumber(int[] array)
        {
            foreach (var item in array)
            {
                if (item >= 0)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static void PrintPostiveNumberViaLinq(int[] array)
        {
            var positiveNumbers = array.Where(x => x >= 0);
            foreach (var item in positiveNumbers)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintPositiveNumberViaDelegate(int[] array, Predicate<int> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentException("Empty delegate");
            }

            foreach (var item in array)
            {
                if (predicate.Invoke(item))
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void PrintPositiveNumberViaAnonymousDelegate(int[] array, IsPositiveNumberDelegate func)
        {
            if (func == null)
            {
                throw new ArgumentException("Empty delegate");
            }

            foreach (var item in array)
            {
                if (func(item))
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static bool IsPositiveNumber(int item)
        {
            if (item >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
