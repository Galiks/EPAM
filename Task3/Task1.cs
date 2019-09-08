using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public static class Task1
    {
        public static void MainFunc()
        {
            List<int> people = new List<int>();
            for (int i = 1; i < 14; i++)
            {
                people.Add(i);
            }

            foreach (var item in people)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 10));

            int j = 1;

            while (people.Count != 1)
            {
                for (int i = j; i < people.Count; i++)
                {
                    people.RemoveAt(i);
                    if (i == people.Count)
                    {
                        j = 1;
                    }
                    if ((i + 1) == people.Count)
                    {
                        j = 0;
                    }
                }
            }


            foreach (var item in people)
            {
                Console.WriteLine(item);
            }
        }
    }
}
