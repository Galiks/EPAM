using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4
{
    public static class Task4
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
