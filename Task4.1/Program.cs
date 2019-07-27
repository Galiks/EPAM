using System;
using System.Linq;

namespace Task4._1
{
    class Program
    {
        private delegate int Compare<T>(T item1, T item2);

        static void Main(string[] args)
        {
            int[] array = new int[] { 5, 9, 0, 3, 6, 84, 4 };

            ArraySort(array, CompareItems);

            CustomSortDemo();


            Console.ReadKey();
        }

        //Task 4.2
        public static void CustomSortDemo()
        {
            string[] array = new string[] { "a", "c", "acb", "aca", "ac", "ab" };

            ArraySort(array, CompareString);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        //Task 4.1
        static void ArraySort<T>(T[] array, Func<T, T, int> func)
        {
            if (func == null)
            {
                throw new ArgumentException("Пустой делегат");
            }

            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < array.Length; i++)
                {
                    if (func(array[i - 1], array[i]) > 0)
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

        public static int CompareItems<T>(T item1, T item2)
        {
            //знаю, что нельзя привязываться к этому методу. Не получилось написать универсальный метод
            //В ином случае воспользовался бы CompareTo, но нельзя
            if (item1.GetHashCode() > item2.GetHashCode())
            {
                return 1;
            }
            else if (item1.GetHashCode() < item2.GetHashCode())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static int CompareString(string item1, string item2)
        {
            if (item1 == null)
            {
                return -1;
            }
            else if (item2 == null)
            {
                return 1;
            }
            else if (item1.Length < item2.Length)
            {
                return -1;
            }
            else if (item1.Length > item2.Length)
            {
                return 1;
            }
            else if (item1.Length == item2.Length)
            {
                return item1.CompareTo(item2);
            }
            else
            {
                return 0;
            }
        }
    }
}
