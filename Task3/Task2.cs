using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task3
{
    public static class Task2
    {
        private static Dictionary<string, int> countOfWord;

        public static Dictionary<string, int> CountOfWord { get => countOfWord; private set => countOfWord = value; }

        public static void MainFunc()
        {
            CountOfWord = new Dictionary<string, int>();

            string pathToFile = Directory.GetCurrentDirectory();
            string filename = "\\Text.txt";
            string fullPathToFile = pathToFile + filename;

            using (StreamReader reader = new StreamReader(fullPathToFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    CalculteWordInLine(line);
                }
            }

            PrintDictionary();
        }

        private static void CalculteWordInLine(string line)
        {
            string[] words = line.Split(new char[] { ' ', ',', '"', '?', '!', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in words)
            {
                string word = item.ToLower();
                if (CountOfWord.ContainsKey(word))
                {
                    CountOfWord[word]++;
                }
                else
                {
                    CountOfWord.Add(word, 1);
                }
            }
        }

        private static void PrintDictionary()
        {
            foreach (var item in CountOfWord.OrderByDescending(w => w.Value))
            {
                Console.WriteLine($"Word: {item.Key} ; Count: {item.Value}");
            }
        }
    }
}
