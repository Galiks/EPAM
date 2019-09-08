using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Task7
{
    public static class MyArray
    {
        private static readonly Random random = new Random();
        public static void PrintArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void AscendingSortingArray(int[] array)
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

        public static void DescendingSortingArray(int[] array)
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
            }
            while (swapped != false);
        }

        public static void AnotherAscendingSortingArray(int[] array)
        {
            Array.Sort(array);
        }

        public static void AnotherDescendingSortingArray(int[] array)
        {
            Array.Sort(array);
            Array.Reverse(array);
        }

        public static int[] CreateInt32Array()
        {
            int lengthOfArray = random.Next(10, 20);
            int[] array = new int[lengthOfArray];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(int.MinValue, int.MaxValue);
            }

            return array;
        }

        public static void Swap<T>(T[] array, int indexOfFirstElement, int indexOfSecondElement)
        {
            if (indexOfFirstElement != indexOfSecondElement)
            {
                T temp = array[indexOfFirstElement];
                array[indexOfFirstElement] = array[indexOfSecondElement];
                array[indexOfSecondElement] = temp;
            }
        }

        public static int GetMaxElementInArray(int[] array)
        {
            int maxElement = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }
            return maxElement;
        }

        public static int GetMinElementInArray(int[] array)
        {
            int minElement = int.MaxValue;
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
