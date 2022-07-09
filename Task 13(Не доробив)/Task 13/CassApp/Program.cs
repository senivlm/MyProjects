using CassApp.Data;

namespace CassApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICollection<Client> clients = ClientGenerator.Generate(15);
            using(var sw = new StreamWriter(@"C:\Users\fly96\Desktop\CassApp\CassApp\Person.txt"))
            {
                foreach (var client in clients)
                {
                    sw.WriteLine(client);
                }
            }

            
           


        }
    }
}