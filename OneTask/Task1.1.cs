using System;
using System.Linq;

namespace OneTask
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var array = CreateInt32Array();
            PrintArray(array);
            Console.WriteLine();
            Array.Sort(array);
            PrintArray(array);
            Console.Read();
        }

        /// <summary>
        /// Task 1.1
        /// </summary>
        private static void GetAreaOfRectangle()
        {
            Console.Write("Enter side A of rectangle: ");
            string sideA = Console.ReadLine();
            Console.Write("Enter side B of rectangle: ");
            string sideB = Console.ReadLine();
            bool checkSideOnValidation = Int32.TryParse(sideA, out int realDoubleSideA) & Int32.TryParse(sideB, out int realDoubleSideB);
            if (checkSideOnValidation)
            {
                Console.WriteLine($"Area of rectangle: {realDoubleSideA * realDoubleSideB}");
            }
            else
            {
                Console.WriteLine("Incorrect number");
            }
        }

        #region Methods for another tasks
        private static void StartProgramm()
        {
            while (true)
            {
                Console.WriteLine("MAIN MENU\nENTER COMMAND: ");
                var command = Console.ReadKey();
                Console.WriteLine();
                switch (command.Key)
                {
                    case ConsoleKey.D1:
                        GetAreaOfRectangle();
                        break;
                    case ConsoleKey.D2:
                        TaskOnePointTwo();
                        break;
                    case ConsoleKey.D3:
                        TaskOnePointThree();
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;
                }
            }
        }

        private static void TaskOnePointTwelve()
        {
            string textOne = Console.ReadLine();
            string textTwo = Console.ReadLine();

            for (int i = 0; i < textOne.Length; i++)
            {
                if (textTwo.Contains(textOne[i]))
                {
                    textOne = textOne.Insert(i, textOne[i].ToString());
                    i++;
                }
            }

            Console.WriteLine(textOne);
        }

        private static void TaskOnePointEleven()
        {
            string text = "!@#$%^&*(,d .f /;g";

            Console.WriteLine(text.Length);

            int length = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    length++;
                }
            }

            Console.WriteLine(length);
        }

        private static void TaskOnePointTen()
        {
            int[,] array = new int[2, 2];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(-10, 10);
                }
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.WriteLine(array[i, j]);
                }
            }

            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
            }

            Console.WriteLine(sum);
        }

        private static void TaskOnePointNine()
        {
            int[] array = new int[10];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    sum += array[i];
                }
            }
            Console.WriteLine(sum);
        }

        private static void TaskOnePointEight()
        {
            int[,,] array = new int[5, 5, 5];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = random.Next(-10, 10);
                    }
                }
            }



            foreach (var i in Enumerable.Range(0, array.GetLength(0)))
            {
                foreach (var j in Enumerable.Range(0, array.GetLength(1)))
                {
                    foreach (var k in Enumerable.Range(0, array.GetLength(2)))
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }

            foreach (var i in Enumerable.Range(0, array.GetLength(0)))
            {
                foreach (var j in Enumerable.Range(0, array.GetLength(1)))
                {
                    foreach (var k in Enumerable.Range(0, array.GetLength(2)))
                    {

                        Console.WriteLine(array[i, j, k]);

                    }
                }
            }
        }

        private static void TaskOnePointSeven()
        {
            int[] array = CreateInt32Array();
            DescendingSortingArray(array);
            AscendingSortingArray(array);
            PrintArray(array);
            Console.WriteLine(GetMaxElementInArray(array));
            Console.WriteLine(GetMinElementInArray(array));
        }

        private static void TaskOnePointFive()
        {
            int sumOfNumber = 0;
            for (int i = 0; i < 1001; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sumOfNumber += i;
                }
            }
            Console.WriteLine(sumOfNumber);
        }

        private static void TaskOnePointFour()
        {
            Console.WriteLine("Enter a number: ");
            string number = Console.ReadLine();
            if (Int32.TryParse(number, out int realNumber))
            {
                if (realNumber > 0)
                {
                    CreateXMASTree(realNumber);
                }
                else
                {
                    Console.WriteLine("Incorrect format of number");
                }
            }
            else
            {
                Console.WriteLine("Incorrect format of number");
            }
        }

        private static void TaskOnePointTwo()
        {
            Console.WriteLine("Enter a number: ");
            string number = Console.ReadLine();
            if (Int32.TryParse(number, out int realNumber))
            {
                if (realNumber > 0)
                {
                    for (int i = 0; i <= realNumber; i++)
                    {

                        Console.WriteLine(new String('*', i));
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect format of number");
                }
            }
            else
            {
                Console.WriteLine("Incorrect format of number");
            }
        }

        private static void TaskOnePointThree()
        {
            Console.WriteLine("Enter a number: ");
            string number = Console.ReadLine();
            if (Int32.TryParse(number, out int realNumber))
            {
                CreateTriangle(realNumber);
            }
            else
            {
                Console.WriteLine("Incorrect format of number");
            }
        }

        private static void CreateTriangle(int heightOfTrinagle)
        {
            if (heightOfTrinagle > 0)
            {
                int indent = 0;
                int centerOfTriangle = heightOfTrinagle / 2;
                for (int i = 0; i <= heightOfTrinagle; i++)
                {
                    if (i % 2 != 0)
                    {
                        string side = new string(' ', centerOfTriangle - indent);
                        Console.WriteLine(side + new String('*', i));
                        indent++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect format of number");
            }
        }

        private static void CreateXMASTree(int heightOfXMASSTree)
        {
            Console.WriteLine("X-MAS TREE");
            for (int j = 1; j < heightOfXMASSTree; j++)
            {
                SetRandomColourForConsole();
                int indent = 0;
                int centerOfTriangle = heightOfXMASSTree / 2;
                for (int i = 1; i <= j; i++)
                {
                    if (i % 2 != 0)
                    {
                        string side = new string(' ', centerOfTriangle - indent);
                        Console.WriteLine(side + new String('*', i));
                        indent++;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        /// <summary>
        /// Устанавливает цвет символов для консоли
        /// </summary>
        private static void SetRandomColourForConsole()
        {
            int numberOfColour = random.Next(0, 10);
            if (numberOfColour == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            if (numberOfColour == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (numberOfColour == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (numberOfColour == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (numberOfColour == 4)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (numberOfColour == 5)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            if (numberOfColour == 6)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            if (numberOfColour == 7)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            if (numberOfColour == 8)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            if (numberOfColour == 9)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
        }

        private static void PrintArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        private static void AscendingSortingArray(int[] array)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i - 1].CompareTo(array[i]) < 0)
                    {
                        Swap(array, i - 1, i);
                        swapped = true;
                    }
                }
            } while (swapped != false);
        }

        private static void DescendingSortingArray(int[] array)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i - 1].CompareTo(array[i]) > 0)
                    {
                        Swap(array, i - 1, i);
                        swapped = true;
                    }
                }
            } while (swapped != false);
        }

        private static int[] CreateInt32Array()
        {
            int lengthOfArray = random.Next(10, 20);
            int[] array = new int[lengthOfArray];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(Int32.MinValue, Int32.MaxValue);
            }

            return array;
        }

        private static void Swap<T>(T[] array, int indexOfFirstElement, int indexOfSecondElement)
        {
            if (indexOfFirstElement != indexOfSecondElement)
            {
                T temp = array[indexOfFirstElement];
                array[indexOfFirstElement] = array[indexOfSecondElement];
                array[indexOfSecondElement] = temp;
            }
        }

        private static Int32 GetMaxElementInArray(int[] array)
        {
            int maxElement = Int32.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }
            return maxElement;
        }

        private static Int32 GetMinElementInArray(int[] array)
        {
            int minElement = Int32.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < minElement)
                {
                    minElement = array[i];
                }
            }
            return minElement;
        } 
        #endregion
    }
}
