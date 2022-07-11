using CassApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp
{
    public class Cashbox : ITerminal
    {
        public int Number { get; }
        public Coordinate Cordinate { get; }
        public event Action<ITerminal>? IsEnabledEvent;
        public event Action<ITerminal>? IsDisabledEvent;
        public Cashbox()
        {
            Number = 0;
            Cordinate = new Coordinate(0, 0);
        }

        public Cashbox(Coordinate cordinate, int number)
        {
            Number = number;
            //cтруктура глибокого копіювання не потребує
            this.Cordinate = cordinate;
        }

        public void TurnOn() => IsEnabledEvent?.Invoke(this);
        public void TurnOff() => IsDisabledEvent?.Invoke(this);

        //магічний метод, який імітує певну дію з клієнтом
        public string ToService(IClient client)
        {
            return string.Format($"{client.ToString()[..11]} was servided by #{Number} box terminal with priority {client.Status}");
        }

    }
}
