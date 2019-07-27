using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4._5
{
    public static class StringExtension
    {
        public static bool IsPositiveInt(this string str)
        {
            //if (str.First() == '-')
            //{
            //    return false;
            //}

            if (str.First() != '+')
            {
                if (!Char.IsNumber(str.First()))
                {
                    return false;
                }
            }


            for (int i = 1; i < str.Length; i++)
            {
                char item = str[i];
                if (!Char.IsNumber(item))
                {
                    return false;
                }
            }


            return true;
        }
    }
}
