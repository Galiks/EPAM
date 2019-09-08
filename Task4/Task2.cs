using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class Task2
    {
        public static void CustomSortDemo()
        {
            string[] array = new string[] { "a", "c", "acb", "aca", "ac", "ab" };

            Task1.ArraySort(array, CompareString);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
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
