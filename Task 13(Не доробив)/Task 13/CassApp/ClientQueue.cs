using CassApp.Data;

namespace CassApp
{
    public class ClientQueue
    {
        private PriorityQueue<Client, Status?> clients;
        private Cashbox cashbox;

        public ClientQueue()
        {
            clients = new PriorityQueue<Client, Status?>();
        }

        public ClientQueue(Cashbox cashbox, params Client[] clients) : this()
        {
            foreach (var client in clients)
            {
                this.clients.Enqueue(client, client.Status);
            }
            this.cashbox = cashbox;
        }

        public void AddToQueue(Client client)
        {
            clients.Enqueue(client, client.Status);
        }

        public void AddToQueue(params Client[] clients)
        {
            foreach (var client in clients)
            {
                this.clients.Enqueue(client, client.Status);
            }
        }
    }
}
