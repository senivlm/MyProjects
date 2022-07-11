using CassApp.Interfaces;
using Task12_3;

namespace CassApp
{
    public static class ClientGenerator
    {
        private static Random random = new Random();

        public static ICollection<IClient> Generate(int amount)
        {
            var clients = new List<Client>();
            for (int i = 0; i < amount; i++)
            {
                clients.Add(new Client($"Pasanger{Guid.NewGuid().ToString()[33..]}", random.Next(18, 100),
                    Guid.NewGuid(), random.Next(100, 1500), new Coordinate(random.Next(0, 15),
                    random.Next(0, 15)), (Status)random.Next(0,5)));
            }

            return (ICollection<IClient>)clients;
        }
    }
}
