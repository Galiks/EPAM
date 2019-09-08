using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public static class Task1
    {
        public static void PrintAreaOfRectangle()
        {
            Console.Write("Enter side A of rectangle: ");
            string sideA = Console.ReadLine();
            Console.Write("Enter side B of rectangle: ");
            string sideB = Console.ReadLine();
            bool checkSideOnValidation = int.TryParse(sideA, out int realDoubleSideA) & Int32.TryParse(sideB, out int realDoubleSideB);
            if (checkSideOnValidation)
            {
                Console.WriteLine($"Area of rectangle: {realDoubleSideA * realDoubleSideB}");
            }
            else
            {
                Console.WriteLine("Incorrect number");
            }
        }
    }
}
