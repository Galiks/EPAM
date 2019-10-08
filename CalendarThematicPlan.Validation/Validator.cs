using System.Text.RegularExpressions;

namespace CalendarThematicPlan.Validation
{
    public static class Validator
    {
        private const string patternEmail = @"\b[A-Za-zА-ЯёЁ0-9]{1}\S+[A-Za-zА-ЯёЁ0-9]{1}\b@[A-Za-zА-ЯёЁ]{2,6}(\.[A-Za-zА-ЯёЁ0-9-]+)+";
        public static bool IsStringsNull(params string[] strings)
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

        public static bool IsStringsNumbers(params string[] strings)
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
