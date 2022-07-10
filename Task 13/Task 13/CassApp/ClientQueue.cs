using CassApp.Interfaces;

namespace CassApp
{
    public class ClientQueue
    {
        private List<IClient> clients;
        private ITerminal cashbox;
        public int Number { get => cashbox.Number; }
        public int Amount { get => clients.Count; }
        public event Action<ClientQueue> OverCrowdedEvent;

        private int maxAmount = 10;

        public ClientQueue()
        {
            clients = new List<IClient>();
        }

        public ClientQueue(ITerminal cashbox, int maxAmount, params IClient[] clients) : this()
        {
            foreach (var client in clients)
            {
                this.clients.Add(client);
            }
            this.cashbox = cashbox;
            this.maxAmount = maxAmount;
        }

        public ICollection<IClient> GetClients() => clients.ToList();
        public void RemoveClients() => clients.Clear();

        public void AddToQueue(IClient client)
        {
            clients.Add(client);
            if(clients.Count > maxAmount)
            {
                OverCrowdedEvent?.Invoke(this);
            }
        }

        public void AddToQueue(params IClient[] clients)
        {
            foreach (var client in clients)
            {
                this.clients.Add(client);
            }
            if (this.clients.Count > maxAmount)
            {
                OverCrowdedEvent?.Invoke(this);
            }
        }

        public void AddToQueue(List<IClient> clients)
        {
            foreach (var client in clients)
            {
                this.clients.Add(client);
            }
            if (this.clients.Count > maxAmount)
            {
                OverCrowdedEvent?.Invoke(this);
            }
        }

        public string Dequeue(IClient client)
        {
            var text = cashbox.ToService(client);
            clients.Remove(client);
            return text;
        }
    }
}
