using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task4._4
{
    public static class ArrayOfIntegerExtension
    {
        public static int GetSumOfNumbersWithLinq(this int[] array)
        {
            return array.Sum();
        }

        public static int GetSumOfNumbers(this int[] array)
        {
            int sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }
    }
}
