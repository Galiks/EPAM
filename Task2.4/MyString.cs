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
        private int _length;

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

        public int Length { get => -_length; private set => _length = value; }

        public MyString(char[] line)
        {
            Line = line;
            Length = Line.Length;
        }

        public override string ToString()
        {
            foreach (var item in Line)
            {
                Console.Write(item);
            }
            return null;
        }

        public int CompareTo(string value)
        {
            if (value.Length > Length)
            {
                return -1;
            }
            else if (value.Length == Length)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int IndexOf(char letter)
        {
            for (int i = 0; i < Length; i++)
            {
                if (Line[i] == letter)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Contains(char letter)
        {
            foreach (var item in Line)
            {
                if (item == letter)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(MyString firstString, char[] secondString)
        {
            if (firstString.Length == secondString.Length)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(MyString firstString, char[] secondString)
        {
            if (firstString.Length != secondString.Length)
            {
                return true;
            }
            return false;
        }
    }
}
