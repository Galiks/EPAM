using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._4
{
    class MyString
    {
        private char[] line;
        public char[] Line
        {
            get { return line; }
            set { line = value; }
        }

        public char this[int index]
        {
            get
            {
                try
                {
                    return Line[index];
                }
                catch (ArgumentOutOfRangeException e)
                {
                    throw new ArgumentOutOfRangeException("Такого элемента нет");
                }
            }
        }

        public MyString(char[] line)
        {
            Line = line;
        }

        //public static bool operator >(char[] firstString, char[] secondString)
        //{
        //    return firstString.Length > secondString.Length;
        //}

        //public static bool operator <(char[] firstString, char[] secondString)
        //{
        //    return firstString.Length < secondString.Length;
        //}
    }
}
