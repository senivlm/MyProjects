using System.IO;

namespace Task10
{
    static class Reader
    {
        public static string ReadText(string filePath)
        {
            string result = "";
            try
            {
                if (!File.Exists(filePath)) throw new FileNotFoundException("Not found dictionry");
                using (StreamReader reader = new StreamReader(filePath))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public static Dictionary<string, string> ReadDictionre(string filePath)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (!File.Exists(filePath)) throw new FileNotFoundException("Not found dictionry");
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string temp = reader.ReadLine();
                        try
                        {
                            var str = temp.Split('-');
                            if (str.Length != 2) throw new ArgumentException("Incorrect pair of key - value");
                            result.Add(str[0], str[1]);
                        }
                        catch (ArgumentException)
                        {
                            throw;
                        }
                    }
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public static void WriteToDictionary(string key, string value, string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) throw new FileNotFoundException("Not found dictionry");
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.Write("\n");
                    writer.Write($"{key}-{value}");
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static bool AddToDictionary(Translator translator, string word)
        {
            if (translator == null || word == null)
            {
                return false;
            }
            Console.WriteLine($"Введiть замiну для слова {word}");
            string value = Console.ReadLine();
            translator.AddTranslation(word, value);
            Reader.WriteToDictionary(word, value, @"../../../Dictionary.txt");
            return true;
        }
    }
}