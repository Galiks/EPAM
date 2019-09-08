using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public static class Task12
    {
        public static void CharDoublerMethod()
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
