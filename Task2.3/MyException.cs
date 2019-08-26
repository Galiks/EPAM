﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._3
{
    public static class MyException
    {
        public static void IsLetterOnly(string str)
        {
            foreach (char letter in str.ToCharArray())
            {
                if (!Char.IsLetter(letter))
                {
                    throw new Exception("Invalid type of line");
                }
            }
        }

        public static void IsNotNowDate(string str)
        {
            DateTime isNow = DateTime.Now.Date;

            if (DateTime.TryParse(str, out DateTime date))
            {
                if (date == isNow)
                {
                    throw new Exception("Invalid type of line");
                }
            }
            else
            {
                throw new Exception("Invalid type of line");
            }
        }

        public static void IsNotNowDate(DateTime date)
        {
            DateTime isNow = DateTime.Now.Date;
            if (date == isNow)
            {
                throw new Exception("Invalid date");
            }
        }
    }
}