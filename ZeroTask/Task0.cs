using System;
using System.Text;

namespace ZeroTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сommands are entered from the keyboard!");
            Console.WriteLine($"Task 0.1 - 1\n" +
                    $"Task 0.2 - 2\n" +
                    $"Task 0.3 - 3\n" +
                    $"EXIT - Esc");
            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command: ");
                var command = Console.ReadKey();
                Console.WriteLine();
                switch (command.Key)
                {
                    case ConsoleKey.D1:
                        TaskZeroPointOne();
                        break;
                    case ConsoleKey.D2:
                        TaskZerpPointTwo();
                        break;
                    case ConsoleKey.D3:
                        TaskZeroPointThree();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;
                }
            }
        }

        private static void TaskZeroPointThree()
        {
            Console.Write("Enter a unsigned odd number: ");
            string number = Console.ReadLine();
            if (Int32.TryParse(number, out int realNumber))
            {
                if (realNumber > 0 && realNumber % 2 != 0)
                {
                    int centerOfSquare = realNumber / 2 + 1;
                    for (int i = 0; i < realNumber; i++)
                    {
                        if (i == centerOfSquare - 1)
                        {
                            string side = new String('*', centerOfSquare - 1);
                            Console.WriteLine($"{side} {side}");
                        }
                        else
                        {
                            Console.WriteLine(new String('*', realNumber));
                        }
                    }
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

        private static void TaskZerpPointTwo()
        {
            Console.Write("Enter a unsigned number: ");
            string number = Console.ReadLine();
            if (Int32.TryParse(number, out int realNumber))
            {
                if (realNumber > 0)
                {
                    if (IsSimpleNumber(realNumber))
                    {
                        Console.WriteLine($"{realNumber} is simple");
                    }
                    else
                    {
                        Console.WriteLine($"{realNumber} is not simple");
                    }
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

        private static bool IsSimpleNumber(int realNumber)
        {
            for (int i = 2; i <= Math.Sqrt(realNumber); i++)
            {
                if (realNumber % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static void TaskZeroPointOne()
        {
            Console.Write("Enter a unsigned number: ");
            string number = Console.ReadLine();
            if (Int32.TryParse(number, out int realNumber))
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

        private static string GetStringOfNumbers(int lastNumber)
        {
            if (lastNumber <= 50000)
            {
                return GetStringOfNumberForSmallNumber(lastNumber);
            }
            else
            {
                return GetStringOfNumberForBigNumber(lastNumber);
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

        private static string GetStringOfNumberForSmallNumber(int lastNumber)
        {
            string result = "";
            for (int i = 1; i <= lastNumber; i++)
            {
                if (i == lastNumber)
                {
                    result += i;
                }
                else
                {
                    result += $"{i}, ";
                }
            }
            return result;
        }
    }
}
