using ADO.NET_Task_3_b;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.StartGame();

            Console.ReadKey();
        }
    }
}
