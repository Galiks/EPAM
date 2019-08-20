using System.Text.RegularExpressions;

namespace RegexTask
{
    public static class Task2
    {
        private const string patternTags = "<.+?>";
        private const string symbolForReplace = "_";

        public static string GetTextWithoutHtmlTags(string input)
        {
            return Regex.Replace(input, patternTags, symbolForReplace);
        }
    }
}