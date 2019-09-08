using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class Task1
    {
        private delegate int Compare<T>(T item1, T item2);

        public static void ArraySort<T>(T[] array, Func<T, T, int> func)
        {
            if (func == null)
            {
                throw new ArgumentException("Empty delegate");
            }

            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < array.Length; i++)
                {
                    //решил опробовать операцию "?."
                    if (func?.Invoke(array[i - 1], array[i]) > 0)
                    {
                        Swap(ref array[i - 1], ref array[i]);
                        swapped = true;
                    }
                }
            }
            while (swapped != false);
        }

        public static void Swap<T>(ref T first, ref T second)
        {
            var temp = first;
            first = second;
            second = temp;
        }
    }
}
