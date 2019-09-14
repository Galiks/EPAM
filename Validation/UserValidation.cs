using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public static class UserValidation
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
