using System;
using Task2.Task_1;

namespace Task2.Task_7.Figures
{
    public class Round : IDrawable
    {
        private double radius;

        public Round(Point point, double radius)
        {
            this.Center = point;
            this.Radius = radius;
        }

        private Point Center { get; set; }

        private double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value > 0)
                {
                    radius = value;
                }
                else
                {
                    throw new ArgumentException("Radius is less then zero");
                }
            }
        }

        private double GetArea
        {
            get
            {
                return Radius * Radius * Math.PI;
            }
        }

        public void Draw()
        {
            Console.WriteLine("Draw Round");
        }

        public override string ToString()
        {
            return $"Радиус = {Radius}{Environment.NewLine}Центр: {Center.PointX}:{Center.PointY}{Environment.NewLine}Площадь: {GetArea}{Environment.NewLine}";
        }
    }
}
