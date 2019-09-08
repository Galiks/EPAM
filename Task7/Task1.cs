using System.Text.RegularExpressions;

namespace Task7
{
    public static class Task1
    {
        private const string patternDate = @"\d{2}[\\\/.-]\d{2}[\\\/.-]\d{4}";

        public static bool IsStringHasDate(string date)
        {
            if (Regex.IsMatch(date, patternDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
