using CassApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp
{
    public class Cashbox
    {
        public int Number { get; }
        private Coordinate cordinate;
        private PriorityQueue<Client, Status?> queuePersons;

        public Cashbox()
        {
            Number = 0;
            queuePersons = new();
            cordinate = new Coordinate(0, 0);
        }

        public Cashbox(Coordinate cordinate, int number)
        {
            queuePersons = new();
            Number = number;
            //cтруктура глибокого копіювання не потребує
            this.cordinate = cordinate;
        }

        public string ToService(Client client)
        {
            return client.ToString();
        }

    }
}
