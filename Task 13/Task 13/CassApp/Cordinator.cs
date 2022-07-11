using CassApp.Interfaces;

namespace CassApp
{
    public class Cordinator<T> where T : IClientQueue, new()
    {
        private Dictionary<ITerminal, IClientQueue> queuesToBoxes;

        public Cordinator()
        {
            queuesToBoxes = new Dictionary<ITerminal, IClientQueue>();
        }

        public Cordinator(List<ITerminal> terminals) : this()
        {
            foreach (var box in terminals)
            {
                queuesToBoxes[box] = new T();
                queuesToBoxes[box].Init(box, 10);
                queuesToBoxes[box].OverCrowdedEvent += SelectHighPriority;
                box.IsDisabledEvent += reformateQueues;
            }
        }

        public Cordinator(params ITerminal[] terminals) : this()
        {
            foreach (var box in terminals)
            {
                queuesToBoxes[box] = new T();
                queuesToBoxes[box].Init(box, 10);
                queuesToBoxes[box].OverCrowdedEvent += SelectHighPriority;
                box.IsDisabledEvent += reformateQueues;
            }
        }

        public PriorityQueue<string, Status?> PerformQueue()
        {
            var finalQueue = new PriorityQueue<string, Status?>();
            foreach (var queue in queuesToBoxes.Values)
            {
                foreach (var client in queue.GetClients())
                {
                    finalQueue.Enqueue(queue.Dequeue(client), client.Status);
                }
            }
            queuesToBoxes.Clear();
            return finalQueue;
        }

        public void SimulateCoordination(ICollection<IClient> clients)
        {
            if (areSameAmounts())
            {
                foreach (var client in clients)
                {
                    var terminal = defineClientToTerminal();
                    Thread.Sleep(client.TimeService);
                    queuesToBoxes[terminal].AddToQueue(client);
                }
            }
            else
            {
                foreach (var client in clients)
                {
                    var terminal = defineClientToNearestTerminal(client);
                    Thread.Sleep(client.TimeService);
                    queuesToBoxes[terminal].AddToQueue(client);
                }
            }
        }

        private bool areSameAmounts()
        {
            foreach (var box in queuesToBoxes.Keys)
            {
                if(queuesToBoxes.Values.Select(a => a.Amount == queuesToBoxes[box].Amount).Count() > 1)
                {
                    return true;
                }
            }
            return false;
        }

        private void SelectHighPriority(IClientQueue clientQueue)
        {
            var clients = clientQueue.GetClients();
            clientQueue.RemoveClients();
            List<IClient> clientHighPrior = clients.Where(a => a.Status == Status.Priority1
            || a.Status == Status.Priority2).ToList();
            clientQueue.AddToQueue(clientHighPrior);
        }

        private ITerminal defineClientToTerminal()
        {
            var terminal = queuesToBoxes.Keys.First();
            foreach (var box in queuesToBoxes.Keys)
            {
                if (queuesToBoxes[terminal].Amount > queuesToBoxes[box].Amount)
                {
                    terminal = box;
                }
            }
            return terminal;
        }

        private ITerminal defineClientToNearestTerminal(IClient client)
        {
            ITerminal terminal = queuesToBoxes.Keys.First();
            foreach(var box in queuesToBoxes.Keys)
            {
                if (box.Cordinate.ComputeDistance(client.Coordinate) <
                    terminal.Cordinate.ComputeDistance(client.Coordinate))
                {
                    terminal = box;
                }
            }
            return terminal;
        }

        private void reformateQueues(ITerminal terminal)
        {
            SimulateCoordination(queuesToBoxes[terminal].GetClients());
        }
    }
}
