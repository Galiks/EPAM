using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._2
{
    public class Triangle
    {
        private double sideA;
        private double sideB;
        private double sideC;

        private double perimeter;
        private double area;

        public double SideA
        {
            get
            {
                return sideA;
            }
            private set
            {
                if (value > 0)
                {
                    sideA = value;
                }
            }
        }
        public double SideB
        {
            get
            {
                return sideB;
            }
            private set
            {
                if (value > 0)
                {
                    sideB = value;
                }
            }
        }
        public double SideC
        {
            get
            {
                return sideC;
            }
            private set
            {
                if (CheckSideC(value))
                {
                    sideC = value;
                }
                else
                {
                    throw new Exception("This triangle does not exist");
                }
            }
        }

        public double Perimeter { get => perimeter; private set => perimeter = value; }
        public double Area { get => area; private set => area = value; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            Perimeter = CalculatePerimeter();
            Area = CalculateArea();
        }

        private double CalculateArea()
        {
            double halfOfPerimeter = Perimeter / 2;
            double area = Math.Sqrt(halfOfPerimeter 
                * (halfOfPerimeter - SideA)
                * (halfOfPerimeter - SideB)
                * (halfOfPerimeter - SideC));
            return area;
        }

        private double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

        private bool CheckSideC(double sideC)
        {
            if ((sideA + sideB > sideC) && (sideA + sideC > sideB) && (sideB + sideC > sideA))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
