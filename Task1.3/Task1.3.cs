using System;

namespace Task1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTriangle();
        }

        private static void PrintTriangle()
        {
            Console.WriteLine("Enter a number: ");
            string number = Console.ReadLine();
            if (Int32.TryParse(number, out int realNumber))
            {
                CreateTriangle(realNumber);
            }
            else
            {
                Console.WriteLine("Incorrect format of number");
            }
        }

        private static void CreateTriangle(int heightOfTrinagle)
        {
            if (heightOfTrinagle > 0)
            {
                int indent = 0;
                int centerOfTriangle = heightOfTrinagle / 2;
                for (int i = 0; i <= heightOfTrinagle; i++)
                {
                    if (i % 2 != 0)
                    {
                        string side = new string(' ', centerOfTriangle - indent);
                        Console.WriteLine(side + new String('*', i));
                        indent++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect format of number");
            }
        }
    }
}
