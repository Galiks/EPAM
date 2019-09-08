using System;
using System.Text;

namespace Task0
{
    public static class Task1
    {
        public static void TaskZeroPointOne()
        {
            Console.Write("Enter a unsigned number: ");
            string number = Console.ReadLine();
            if (int.TryParse(number, out int realNumber))
            {
                if (realNumber > 0)
                {
                    Console.WriteLine(GetStringOfNumberForBigNumber(realNumber));
                }
                else
                {
                    Console.WriteLine("Incorrect format of number");
                }
            }
            else
            {
                Console.WriteLine("Incorrect format of number");
            }
        }

        private static string GetStringOfNumberForBigNumber(int lastNumber)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= lastNumber; i++)
            {
                if (i == lastNumber)
                {
                    result.Append(i);
                }
                else
                {
                    result.Append($"{i}, ");
                }
            }
            return result.ToString();
        }
    }
}
