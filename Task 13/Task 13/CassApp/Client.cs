using CassApp.Interfaces;

namespace CassApp
{
    public class Client : Person, IClient
    {
        public Guid Id { get; }
        public int TimeService { get; }
        //cтруктуру передаємо по значенню
        public Coordinate Coordinate { get; }
        public Status? Status { get; }

        private string name;
        public string Name => name;
        private int age;
        public int Age => age;

        public Client(string name, int age, Guid id, int timeService, Coordinate coordinate, Status? status)
        {
            this.name = name;
            this.age = age;
            Id = id;
            TimeService = timeService;
            Coordinate = coordinate;
            Status = status;
        }

        public override string ToString()
        {
            return $"{Name} {Age} {Id} {TimeService} {Coordinate} {Status}";
        }
    }
}
