using System;
using System.Collections.Generic;

namespace Task3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> dynamicArray = new DynamicArray<int>();

            for (int i = 0; i < 20; i++)
            {
                dynamicArray.Add(i);
            }

            Console.WriteLine(dynamicArray.Length);
            Console.WriteLine(dynamicArray.Capacity);

            foreach (var item in dynamicArray)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
