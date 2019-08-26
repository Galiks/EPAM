using System;
using System.Text.RegularExpressions;

namespace RegexTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Task 1

            Console.WriteLine("Enter the text: ");
            string userText = Console.ReadLine();
            if (Task1.IsStringHasDate(userText))
            {
                Console.WriteLine($"Text \"{userText}\" has date");
            }
            else
            {
                Console.WriteLine($"Text \"{userText}\" don't has date");
            }

            #endregion Task 1

            #region Task 3

            string textWithEmails = "Иван: ivan@mail.ru, Петр: p_ivanov@mail.rol.ru, 123@1.1";
            var emails = Task3.GetEmail(textWithEmails);
            foreach (var item in emails)
            {
                Console.WriteLine(item);
            }

            #endregion Task 3

            #region Task 2

            string textWithTags = "<b>Это</b> текст <i>с</i> <font color=\"red\">HTML</font> кодами ";
            string textWithoutTags = Task2.GetTextWithoutHtmlTags(textWithTags);
            Console.WriteLine(textWithoutTags);

            #endregion Task 2

            Console.Read();
        }
    }
}