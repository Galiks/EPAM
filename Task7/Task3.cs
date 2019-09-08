using System.Collections;
using System.Text.RegularExpressions;

namespace Task7
{
    public static class Task3
    {
        //пытался сделать всё через метасимволы контекста "^" и "$", но не вышло
        private const string patternEmail = @"\b[A-Za-zА-ЯёЁ0-9]{1}\S+[A-Za-zА-ЯёЁ0-9]{1}\b@[A-Za-zА-ЯёЁ]{2,6}(\.[A-Za-zА-ЯёЁ0-9-]+)+";

        public static IEnumerable GetEmail(string input)
        {
            var result = Regex.Matches(input, patternEmail);

            return result;
        }
    }
}
