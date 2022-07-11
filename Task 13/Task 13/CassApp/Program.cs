using CassApp.Interfaces;
using Task12_3;

namespace CassApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //сгенерували клієнтів
            try
            {
                ICollection<IClient> clients = ClientGenerator.Generate(15);
                using (var sw = new StreamWriter(@"D:\MyProjects\Task 13\Task 13\CassApp\ClientsData"))
                {
                    foreach (var client in clients)
                    {
                        sw.WriteLine(client);
                    }
                }

                //прочитали їх
                var reader = new Reader(@"D:\MyProjects\Task 13\Task 13\CassApp\ClientsData");
                var list = reader.ReadExpresion();
                List<IClient> listClients = new();
                foreach (var item in list)
                {
                    listClients.Add(ClientParser.Parse(item));
                }

                var cashbox1 = new Cashbox(new Coordinate(1, 2), 1);
                var cashbox2 = new Cashbox(new Coordinate(1, 5), 2);
                var cashbox3 = new Cashbox(new Coordinate(1, 8), 3);
                Cordinator<ClientQueue> cordinator = new(cashbox1, cashbox2, cashbox3);
                cordinator.SimulateCoordination(listClients);
                var servicedClients = cordinator.PerformQueue();
                using (var sw = new StreamWriter(@"D:\MyProjects\Task 13\Task 13\CassApp\Results.txt"))
                {
                    int count = servicedClients.Count;
                    for (int i = 0; i < count; i++)
                    {
                        sw.WriteLine(servicedClients.Dequeue());
                    }
                }
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}