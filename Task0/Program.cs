using System;

namespace Task0
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
                        Task1.TaskZeroPointOne();
                        break;
                    case ConsoleKey.D2:
                        Task2.TaskZerpPointTwo();
                        break;
                    case ConsoleKey.D3:
                        Task3.TaskZeroPointThree();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;
                }
            }
        }
    }
}
