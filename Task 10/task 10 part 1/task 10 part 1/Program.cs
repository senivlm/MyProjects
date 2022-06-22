using System.IO;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary;
            string text;
            //зчитування
            dictionary = Reader.ReadDictionre(@"../../../Dictionary.txt");
            text = Reader.ReadText(@"../../../Text.txt");
            //логіка
            var translator = new Translator(dictionary, Reader.AddToDictionary);
            string translatedText = translator.TranslateText(text);
            //швидкий вивід
            try
            {
                using(var sr = new StreamWriter(@"../../../Text.txt", true))
                {
                    sr.WriteLine();
                    sr.WriteLine(translatedText);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}