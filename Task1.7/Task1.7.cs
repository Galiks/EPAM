using System;

namespace Task1._7
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            ArrayMethods();
            Console.ReadKey();
        }

        private static void ArrayMethods()
        {
            int[] array = CreateInt32Array();
            AnotherAscendingSortingArray(array);
            DescendingSortingArray(array);
            PrintArray(array);
            AscendingSortingArray(array);
            PrintArray(array);
            AnotherDescendingSortingArray(array);
            PrintArray(array);
            Console.WriteLine(GetMaxElementInArray(array));
            Console.WriteLine(GetMinElementInArray(array));
        }

        private static void PrintArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        private static void AscendingSortingArray(int[] array)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i - 1].CompareTo(array[i]) < 0)
                    {
                        Swap(array, i - 1, i);
                        swapped = true;
                    }
                }
            } while (swapped != false);
        }

        private static void DescendingSortingArray(int[] array)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i - 1].CompareTo(array[i]) > 0)
                    {
                        Swap(array, i - 1, i);
                        swapped = true;
                    }
                }
            } while (swapped != false);
        }

        private static void AnotherAscendingSortingArray(int[] array)
        {
            Array.Sort(array);
        }

        private static void AnotherDescendingSortingArray(int[] array)
        {
            Array.Sort(array);
            Array.Reverse(array);
        }

        private static int[] CreateInt32Array()
        {
            int lengthOfArray = random.Next(10, 20);
            int[] array = new int[lengthOfArray];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(Int32.MinValue, Int32.MaxValue);
            }

            return array;
        }

        private static void Swap<T>(T[] array, int indexOfFirstElement, int indexOfSecondElement)
        {
            if (indexOfFirstElement != indexOfSecondElement)
            {
                T temp = array[indexOfFirstElement];
                array[indexOfFirstElement] = array[indexOfSecondElement];
                array[indexOfSecondElement] = temp;
            }
        }

        private static Int32 GetMaxElementInArray(int[] array)
        {
            int maxElement = Int32.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }
            return maxElement;
        }

        private static Int32 GetMinElementInArray(int[] array)
        {
            int minElement = Int32.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < minElement)
                {
                    minElement = array[i];
                }
            }
            return minElement;
        }
    }
}
