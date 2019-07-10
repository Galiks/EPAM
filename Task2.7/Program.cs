using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2._7.Figures;

namespace Task2._7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDrawable> figures = new List<IDrawable>()
            {
                new Line(new _1.Point(5,5), new _1.Point(10,10)),
                new Circle(10,14,5),
                new Rectangle(6,8),
                new Round(new _1.Point(9,2), 4),
                new Ring(3,3,2,1),
            };

            foreach (var item in figures)
            {
                item.Draw();
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
