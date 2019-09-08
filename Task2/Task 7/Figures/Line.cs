using System;
using Task2.Task_1;

namespace Task2.Task_7.Figures
{
    public class Line : IDrawable
    {
        private double length;

        public double Length
        {
            get { return length; }
            private set { length = value; }
        }


        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }

        public Line(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
            Length = GetLength();
        }

        public void Draw()
        {
            Console.WriteLine("Draw Line");
        }

        public override string ToString()
        {
            return $"Начало: {Point1.PointX}:{Point1.PointY}{Environment.NewLine}Конец: {Point2.PointX}:{Point2.PointY}{Environment.NewLine}Длина: {Length}{Environment.NewLine}";
        }

        private double GetLength()
        {
            Point vector = Point1 - Point2;
            return Math.Sqrt(Math.Pow(vector.PointX, 2) + Math.Pow(vector.PointY, 2));
        }
    }
}
