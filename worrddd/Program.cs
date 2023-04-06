using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace worrddd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the letters: ");
            string letters = Console.ReadLine();

            List<string> words = GenerateWords(letters);
            Console.WriteLine($"Words generated: {words.Count}");
            Console.WriteLine("Words:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.ReadLine();
        }

        private static List<string> GenerateWords(string letters)
        {
            List<string> words = new List<string>();
            string[] letterArray = letters.ToUpper().Split(',');

            List<string> dictionary = LoadWords();

            foreach (string word in dictionary)
            {
                if (word.Length < 3) // Minimum kelime uzunluğu 3
                {
                    continue;
                }
                string temp = letters;

                bool validWord = true;

                foreach (char letter in word)
                {
                    if (!temp.Contains(letter))
                    {
                        validWord = false;
                        break;
                    }
                    else
                    {
                        temp = temp.Remove(temp.IndexOf(letter), 1);
                    }
                }

                if (validWord)
                {
                    words.Add(word);
                }
            }

            return words;
        }

        private static List<string> LoadWords()
        {
            List<string> words = new List<string>();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "fatat.txt");
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(line);
                }
            }

            return words;
        }
    }
}
