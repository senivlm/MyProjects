namespace Task_14.Factories
{
    //для рефлексії, а саме універсальної взаємодії з користувачем
    public class NameLabel : Attribute
    {
        public string Name { get; }

        public NameLabel(string name)
        {
            Name = name;
        }
    }
}

