using System;

namespace Task1._4
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            PrintXMASTree();
            Console.ReadLine();
        }

        private static void PrintXMASTree()
        {
            Console.WriteLine("Enter a number: ");
            string number = Console.ReadLine();
            if (Int32.TryParse(number, out int realNumber))
            {
                if (realNumber > 0)
                {
                    CreateXMASTree(realNumber);
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

        private static void CreateXMASTree(int heightOfXMASSTree)
        {
            Console.WriteLine("X-MAS TREE");
            if (heightOfXMASSTree > 0)
            {
                for (int j = 1; j < heightOfXMASSTree; j++)
                {
                    SetRandomColourForConsole();
                    int indent = 0;
                    int centerOfTriangle = heightOfXMASSTree / 2;
                    for (int i = 1; i <= j; i++)
                    {
                        if (i % 2 != 0)
                        {
                            string side = new string(' ', centerOfTriangle - indent);
                            Console.WriteLine(side + new String('*', i));
                            indent++;
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.White; 
            }
            else
            {
                Console.WriteLine("Incorrect number");
            }
        }

        /// <summary>
        /// Устанавливает цвет символов для консоли
        /// </summary>
        private static void SetRandomColourForConsole()
        {
            int numberOfColour = random.Next(0, 10);
            if (numberOfColour == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            if (numberOfColour == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (numberOfColour == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (numberOfColour == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (numberOfColour == 4)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (numberOfColour == 5)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            if (numberOfColour == 6)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            if (numberOfColour == 7)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            if (numberOfColour == 8)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            if (numberOfColour == 9)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
        }
    }
}
