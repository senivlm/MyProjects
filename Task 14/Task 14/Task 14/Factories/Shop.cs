using Task_14.Factories.PatternStratehy;

namespace Task_14.Factories
{
    public abstract class Shop
    {
        private IDialogueStrategy dialogue;

        public Shop(IDialogueStrategy dialogue)
        {
            this.dialogue = dialogue;
        }

        public void StartPurchasing()
        {
            var type = GetType();
            dialogue.StartProcess(type, this);
        }
    }
}

