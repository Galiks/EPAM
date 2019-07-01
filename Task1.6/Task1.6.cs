using OneTask;
using System;

namespace Task1._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void SetFontAdjustment()
        {
            Console.WriteLine("Сommands are entered from the keyboard!");
            Font font = new Font();
            while (true)
            {
                Console.WriteLine($"Параметры надписи: {font.GetSignatureSettings()}");
                Console.WriteLine("Введите:\n\t 1: bold\n\t 2: italic \n\t 3: underline");
                var command = Console.ReadKey();
                Console.WriteLine();
                switch (command.Key)
                {
                    case ConsoleKey.D1:
                        font.SetBold();
                        break;
                    case ConsoleKey.D2:
                        font.SetItalic();
                        break;
                    case ConsoleKey.D3:
                        font.SetUnderline();
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;
                }
            }
        }
    }
}
