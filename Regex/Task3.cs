using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexTask
{
    public static class Task3
    {
        //пытался сделать всё через метасимволы контекста "^" и "$", но не вышло
        private const string patternEmail = @"\b[A-Za-zА-ЯёЁ0-9]{1}\S+[A-Za-zА-ЯёЁ0-9]{1}\b@[A-Za-zА-ЯёЁ]+(\.[A-Za-zА-ЯёЁ0-9-]+)+";

        public static IEnumerable GetEmail(string input)
        {
            var result = Regex.Matches(input, patternEmail);

            return result;
        }
    }
}