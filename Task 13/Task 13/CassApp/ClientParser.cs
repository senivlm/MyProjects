using CassApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp
{
    public static class ClientParser
    {
        public static IClient Parse(string text)
        {
            Random random = new Random();
            string[] atributes = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = atributes[0];
            int age;
            Guid guid;
            int timeService;
            Coordinate coordinate;
            Status? status = null;
            if (!int.TryParse(atributes[1], out age))
            {
                throw new FormatException();
            }
            if (!Guid.TryParse(atributes[2], out guid))
            {
                throw new FormatException();
            }
            if (!int.TryParse(atributes[3], out timeService))
            {
                throw new FormatException();
            }
            if (!Coordinate.TryParse(atributes[4], out coordinate))
            {
                throw new FormatException();
            }
            if (Enum.TryParse(typeof(Status), atributes[5], out object? obj))
            {
                status = (Status)obj;
            }

            return new Client
                (name, age, guid, timeService, coordinate, status);
        }
    }
}
