﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task3._2
{
    class Program
    {
        private static Dictionary<string, int> countOfWord;

        public static Dictionary<string, int> CountOfWord { get => countOfWord; private set => countOfWord = value; }

        static void Main(string[] args)
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

            Console.ReadKey();
        }

        private static void CalculteWordInLine(string line)
        {
            string[] words = line.Split(new char[] { ' ', ',' ,'"', '?', '!', '(', ')'}, StringSplitOptions.RemoveEmptyEntries);
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
