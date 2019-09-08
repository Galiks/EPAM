using System;

namespace Task1
{
    public static class Task4
    {
        private static readonly Random random = new Random();
        public static void PrintXMASTree()
        {
            Console.WriteLine("Enter a number: ");
            string number = Console.ReadLine();
            if (int.TryParse(number, out int realNumber))
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
                            Console.WriteLine(side + new string('*', i));
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
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            int numberOfColour = random.Next(1, 16);
            Console.ForegroundColor = colors[numberOfColour];
        }
    }
}
