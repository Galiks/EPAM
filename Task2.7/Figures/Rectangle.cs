using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._7.Figures
{
    public class Rectangle : IDrawable
    {
        private double sideA;
        private double sideB;

        public Rectangle(double sideA, double sideB)
        {
            this.sideA = sideA;
            this.sideB = sideB;
        }

        double SideA
        {
            get
            {
                return sideA;
            }
            set
            {
                if (value > 0)
                {
                    sideA = value;
                }
                else
                {
                    throw new Exception("Invalid value");
                }
            }
        }

        double SideB
        {
            get
            {
                return sideB;
            }
            set
            {
                if (value > 0)
                {
                    sideB = value;
                }
                else
                {
                    throw new Exception("Invalid value");
                }
            }
        }

        public override string ToString()
        {
            return $"Сторона A: {SideA}{Environment.NewLine}Сторона B: {SideB}{Environment.NewLine}";
        }

        public void Draw()
        {
            Console.WriteLine("Draw Rectangle");
        }
    }
}
