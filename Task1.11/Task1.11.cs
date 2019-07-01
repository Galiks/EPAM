using System;

namespace Task1._11
{
    class Program
    {
        static void Main(string[] args)
        {
            AverageStringLengthMethod();
        }

        private static void AverageStringLengthMethod()
        {
            string text = "!@#$%^&*(,d .f /;g";

            Console.WriteLine(text.Length);

            int length = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    length++;
                }
            }

            Console.WriteLine(length);
        }
    }
}
