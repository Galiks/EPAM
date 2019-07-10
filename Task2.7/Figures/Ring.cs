using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2._1;

namespace Task2._7.Figures
{
    public class Ring : IDrawable
    {
        private readonly double area;
        private readonly double circumference;
        private readonly Point center;
        private Circle externalRound;

        public Circle ExternalRound
        {
            get { return externalRound; }
            private set { externalRound = value; }
        }

        private Circle internalRound;

        //Нужна ли проверка на то, что внешний круг был строго меньше внешнего?
        public Circle InternalRound
        {
            get { return internalRound; }
            private set { internalRound = value; }
        }

        public double GetArea => area;

        public double GetCircumference => circumference;

        public Point Center => center;

        public Ring(double pointX, double pointY, double externalRadius, double internalRadius)
        {
            ExternalRound = new Circle(pointX, pointY, externalRadius);
            InternalRound = new Circle(pointX, pointY, internalRadius);
            area = CalculateArea();
            center = ExternalRound.Center;
            circumference = CalculateCircumference();
        }

        private double CalculateArea()
        {
            return ExternalRound.GetArea - InternalRound.GetArea;
        }

        private double CalculateCircumference()
        {
            return ExternalRound.GetCircumference + InternalRound.GetCircumference;
        }

        public override string ToString()
        {
            return $"Центр: {Center}{Environment.NewLine}Площадь: {GetArea}{Environment.NewLine}Суммарная длина окружности: {GetCircumference}";
        }

        public void Draw()
        {
            Console.WriteLine("Draw Ring");
        }
    }
}
