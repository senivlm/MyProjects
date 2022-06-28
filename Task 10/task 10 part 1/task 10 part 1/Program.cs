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
            // А цю частинку Ви не хочете захистити?
            string translatedText = translator.TranslateText(text);
            //швидкий вивід
            try
            {
                // Як правило для об'єкта StreamWriter використовують sw))))
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
