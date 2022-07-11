namespace CassApp.Interfaces
{
    public interface IClientQueue
    {
        public int Number { get; }
        public int Amount { get; }
        public event Action<ClientQueue> OverCrowdedEvent;
        public void Init(ITerminal cashbox, int maxAmount, params IClient[] clients);
        public ICollection<IClient> GetClients();
        public void RemoveClients();
        public void AddToQueue(IClient client);
        public void AddToQueue(IList<IClient> client);
        public string Dequeue(IClient client);
    }
}
