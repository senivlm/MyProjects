namespace Task10
{
    class WordDoesntFound : Exception
    {
        public WordDoesntFound() : base()
        {
        }

        public WordDoesntFound(string message) : base(message)
        {
        }
    }
}