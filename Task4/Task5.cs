using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4
{
    public static class Task5
    {
        public static bool IsPositiveInt(this string str)
        {
            //if (str.First() == '-')
            //{
            //    return false;
            //}

            if (str.First() != '+')
            {
                if (!char.IsNumber(str.First()))
                {
                    return false;
                }
            }


            for (int i = 1; i < str.Length; i++)
            {
                char item = str[i];
                if (!char.IsNumber(item))
                {
                    return false;
                }
            }


            return true;
        }
    }
}
