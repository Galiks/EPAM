using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task4
{
    public class Task3
    {
        private event Action<string> SortingIsFinishedEvent;
        private Thread myThread;

        private Thread MyThread { get => myThread; set => myThread = value; }

        public Task3()
        {
            SortingIsFinishedEvent = SortingIsDone;
        }

        private void SortingIsDone(string message)
        {
            Console.WriteLine(message);
        }

        public void StartDemonstration()
        {
            int[] array = new int[] { 5, 9, 0, 3, 6, 84, 4 };
            MyThread = new Thread(() => ArraySort(array, CompareItems));
            MyThread.Start();
        }

        private void ArraySort<T>(T[] array, Func<T, T, int> func)
        {
            if (func == null)
            {
                throw new ArgumentException("Empty delegate");
            }

            Console.WriteLine($"Thread {MyThread.Name} is starting");

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

            SortingIsFinishedEvent?.Invoke("Sorting finised!");

            PrintCollection(array);
        }

        private void PrintCollection<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        private int CompareItems<T>(T item1, T item2)
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

        private void Swap<T>(ref T first, ref T second)
        {
            var temp = first;
            first = second;
            second = temp;
        }
    }
}
