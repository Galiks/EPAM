using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    public static class Validation
    {
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
    }
}
