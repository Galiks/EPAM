using System;
using System.Linq;

namespace Task1._12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void CharDoublerMethod()
        {
            string textOne = Console.ReadLine();
            string textTwo = Console.ReadLine();

            for (int i = 0; i < textOne.Length; i++)
            {
                if (textTwo.Contains(textOne[i]))
                {
                    textOne = textOne.Insert(i, textOne[i].ToString());
                    i++;
                }
            }

            Console.WriteLine(textOne);
        }
    }
}
