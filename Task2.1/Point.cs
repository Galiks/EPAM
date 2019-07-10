using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1
{
    public class Point
    {
        public double PointX { get; private set; }
        public double PointY { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса Point.
        /// </summary>
        /// <param name="pointX">точка на оси X</param>
        /// <param name="pointY">точка на оси Y</param>
        public Point(double pointX, double pointY)
        {
            PointX = pointX;
            PointY = pointY;
        }

        public override string ToString()
        {
            return $"X = {PointX}; Y = {PointY}";
        }

        public static Point operator -(Point a, Point b)
        {
            var pointX = b.PointX - a.PointX;
            var pointY = b.PointY - a.PointY;
            return new Point(pointX, pointY);
        }
    }
}
