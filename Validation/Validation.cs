using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validation
{
    public static class Validation
    {
        private const string patternEmail = @"\b[A-Za-zА-ЯёЁ0-9]{1}\S+[A-Za-zА-ЯёЁ0-9]{1}\b@[A-Za-zА-ЯёЁ]{2,6}(\.[A-Za-zА-ЯёЁ0-9-]+)+";
        public static bool IsRightAge(int age)
        {
            if (age < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsRightEmail(string email)
        {
            if (Regex.IsMatch(email, patternEmail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsEmptyStrings(params string[] strings)
        {
            foreach (var item in strings)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsNumbers(params string[] strings)
        {
            foreach (var item in strings)
            {
                if (!int.TryParse(item, out int result))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
