using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public static class Task11
    {
        public static void AverageStringLengthMethod()
        {
            string text = "!@#$%^&*(,d .f /;g";

            Console.WriteLine(text.Length);

            int length = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    length++;
                }
            }

            Console.WriteLine(length);
        }
    }
}
