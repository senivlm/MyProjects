using System.Text;

namespace Task10
{// коментар показує, що правильно розумієте основу
    //Я змінив клас транслятор так, щоб він займався тільки логікою без зчитування даниx, тим самим
    //притримуючись приницпу single responsibility. Виніс евент на обробку коли в нас
    //слово не знайдено в словнику(для прикладу ми зможемо не тільки з консолі попросити ввід, а
    //ще прив*язати другий метод який змінює наприклад віндовс форму на червоний колір.)
    //Перевірку слова в словнику виніс в інший метод, аби не повторюватись
    class Translator
    {
        private Dictionary<string, string> vocabluary;
        private static readonly int attemptAmount = 3;
        public event Func<Translator, string, bool> NotFoundTranslation;

        public Translator()
        {
            vocabluary = new Dictionary<string, string>();
        }

        public Translator(Dictionary<string, string> vocabluary, Func<Translator, string, bool> addTranslation)
        {
            this.vocabluary = vocabluary;
            NotFoundTranslation = addTranslation;
        }

        public void AddTranslation(string original, string translate)
        {
            vocabluary.Add(original, translate);
        }

        public void ChangeDictionary(Dictionary<string, string> dictionary)
        {
            this.vocabluary = dictionary;
        }

        public string TranslateText(string textToTranslate)
        {
            StringBuilder result = new();
            var words = textToTranslate.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                char temp = ' ';
                string tempWord = "";
                if (char.IsPunctuation(word[word.Length - 1]))
                {
                    translateChecking(word[0..^1]);
                    // не буде врахована умова, що може бути довільна кількість пропусків між словами.Також слід враховувати регістри.
                    tempWord = vocabluary[word[0..^1]] + word[word.Length - 1] + temp;
                }
                else
                {
                    translateChecking(word);
                    tempWord = vocabluary[word];
                }
                result.Append(tempWord + " ");
            }

            return result.ToString();
        }

        private void translateChecking(string word)
        {
            try
            {
                if (!vocabluary.ContainsKey(word))
                {
                    int attempt = 0;
                    while (!NotFoundTranslation.Invoke(this, word) && attemptAmount > attempt)
                    {
                        attempt++;
                    }
                    if (!vocabluary.ContainsKey(word))
                    {
                        throw new WordDoesntFound("not found translation");
                    }
                }
            }
            catch(WordDoesntFound ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
