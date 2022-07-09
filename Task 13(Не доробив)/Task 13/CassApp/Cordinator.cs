using CassApp.Data;

namespace CassApp
{
    public class Cordinator
    {
        private List<Cashbox> cashbox;

        public Cordinator(List<Cashbox> cashbox)
        {
            foreach (Cashbox c in cashbox)
            {
                cashbox.Add(c);
            }
        }

        public Cordinator(int amount)
        {
            cashbox = new List<Cashbox>();
            for (int i = 0; i < amount; i++)
            {
                cashbox.Add(new Cashbox());
            }
        }

        public void SimulateCoordination(ICollection<Client> clients, ICollection<Cashbox> cashboxes)
        {
            var queue = new ClientQueue[cashbox.Count];
            foreach (var client in clients)
            {

            }
        }

        private ClientQueue getMinDistancedQueue(Client client, ICollection<Cashbox> cashboxes)
        {

        }
    }
}
