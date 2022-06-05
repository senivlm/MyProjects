using System;
using System.IO;

namespace Task6_part2
{
    class FileWriteReadManager
    {
        private string filePath;
        private string[] sentences;
        public void DefinePath(string path)
        {
            if(path != null)
            {
                filePath = path;
            }
        }

        public void DivideTextIntoSentences()
        {
            using(var sr = new StreamReader(filePath))
            {
                sentences = sr.ReadToEnd().Split(".", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public void WriteSentencesIntoFile()
        {
            using (var sr = new StreamWriter(filePath, true))
            {
                sr.WriteLine();
                for (int i = 0; i < sentences.Length; i++)
                {
                    sr.WriteLine("    " + sentences[i].Trim());
                }
            }
        }

        public void PrintLongestShortestWordsInEachSentences()
        {
            if(sentences == null)
            {
                throw new NullReferenceException("Sentences was not found. Try to divide text before");
            }
            using (var sr = new StreamWriter(filePath, true))
            {
                string longestWord = "";
                string shortestWord = "";
                sr.WriteLine();
                for (int i = 0; i < sentences.Length; i++)
                {
                    string[] words = sentences[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length > 0)
                    {
                        shortestWord = words[0];
                    }
                    for (int j = 0; j < words.Length; j++)
                    {
                        if(words[j].Length > longestWord.Length)
                        {
                            longestWord = words[j];
                        }
                        if (words[j].Length < shortestWord.Length)
                        {
                            shortestWord = words[j];
                        }
                    }
                    sr.WriteLine($"shortest word in {i} sentence: " + shortestWord);
                    sr.WriteLine($"longest word  in {i} sentence: " + longestWord);
                }
            }
        }

        public static string ReadInfoFromStream(string path)
        {
            string text;
            using (var sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }

        public static void WriteInFile(string text, string path)
        {
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(text);
            }
        }
    }
}
