using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b.Battlefields
{
    public class Battlefield
    {
        private int width;

        public int Width
        {
            get { return width; }
            private set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new Exception("Ширина должна быть строго больше нуля!");
                }
            }
        }

        private int height;

        public int Height
        {
            get { return height; }
            private set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new Exception("Высота должна быть строго больше нуля!");
                }
            }
        }

        public Battlefield(int width, int height, int numbersOfMonsters, int numberOfObstacles, int numberOfBonuses)
        {
            Width = width;
            Height = height;
            NumberOfMonsters = numbersOfMonsters;
            NumberOfObstacles = numberOfObstacles;
            NumberOfBonuses = numberOfBonuses;
        }

        public int NumberOfMonsters { get; set; }
        public int NumberOfObstacles { get; set; }
        public int NumberOfBonuses { get; set; }
    }
}
