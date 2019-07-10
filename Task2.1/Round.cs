using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1
{
    public class Round
    {
        /// <summary>
        /// Задумалсяна этом месте. Стоит ли каждый раз пересчитывать значение или же можно сохранить его, а потом использовать
        /// </summary>
        private readonly double circumference;
        private readonly double area;
        private double radius;
        private Point center;
        /// <summary>
        /// Возвращает координаты центра окружности
        /// </summary>
        public Point Center
        {
            get
            {
                return center;
            }
            private set
            {
                center = value;
            }
        }
        /// <summary>
        /// Возвращает или изменяет радиус окружности
        /// </summary>
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value > 0)
                {
                    radius = value;
                }
                else
                {
                    throw new ArgumentException("Radius less or equal zero");
                }
            }
        }
        /// <summary>
        /// Возвращает длину окружности
        /// </summary>
        public double GetCircumference { get => circumference; }
        /// <summary>
        /// Возвращает площадь окружности
        /// </summary>
        public double GetArea { get => area; }

        /// <summary>
        /// Инициализирует новый экземпляр класса Round.
        /// </summary>
        /// <param name="pointX">Точка центра окружности на оси X</param>
        /// <param name="pointY">Точка центра окружности на оси Y</param>
        /// <param name="radius">Радиус окружности</param>
        public Round(double pointX, double pointY, double radius)
        {
            Center = new Point(pointX, pointY);
            Radius = radius;
            circumference = CalculateCircumference();
            area = CalculateArea();
        }

        /// <summary>
        /// Подсчитывает длину окружности
        /// </summary>
        /// <returns>длина окружности</returns>
        private double CalculateCircumference()
        {
            return 2 * Math.PI * Radius;
        }

        /// <summary>
        /// Подсчитывает площадь окружности 
        /// </summary>
        /// <returns>площадь окружности</returns>
        private double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
