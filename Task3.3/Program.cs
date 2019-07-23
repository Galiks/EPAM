using System;
using System.Collections.Generic;
using System.Text;

namespace Task3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3};
            DynamicArray<int> dynamicArray = new DynamicArray<int>(list);

            StringBuilder stringBuilder = new StringBuilder();

            Console.WriteLine(stringBuilder.Length);
            Console.WriteLine(stringBuilder.Capacity);

            for (int i = 0; i < 10; i++)
            {
                stringBuilder.Append(i.ToString());
            }

            for (int i = 0; i < 6; i++)
            {
                stringBuilder.Append(i.ToString());
            }

            Console.WriteLine();
            Console.WriteLine(stringBuilder.Length);
            Console.WriteLine(stringBuilder.Capacity);

            for (int i = 0; i < 1; i++)
            {
                stringBuilder.Append(i.ToString());
            }

            Console.WriteLine();
            Console.WriteLine(stringBuilder.Length);
            Console.WriteLine(stringBuilder.Capacity);

            //dynamicArray.PrintArray();



            //Console.WriteLine();

            //dynamicArray.PrintArray();

            //Console.WriteLine(dynamicArray.Length);
            //Console.WriteLine(dynamicArray.Capacity);

            Console.ReadKey();
        }
    }
}
