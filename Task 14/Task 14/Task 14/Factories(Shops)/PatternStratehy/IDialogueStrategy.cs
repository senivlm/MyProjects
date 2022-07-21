namespace Task_14.Factories.PatternStratehy
{
    //тільки одну стретагію написав, але можна розширити легко і написати 
    //наприклад для він форми
    public interface IDialogueStrategy
    {
        public void StartProcess(Type type, object obj);
    }
}

