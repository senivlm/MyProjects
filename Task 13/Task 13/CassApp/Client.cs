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

        public Client(string name, int age, Guid id, int timeService, Coordinate coordinate, Status? status) : base(name, age)
        {
            Id = id;
            TimeService = timeService;
            Coordinate = coordinate;
            Status = status;
        }

        public override string ToString()
        {
            return $"{name} {age} {Id} {TimeService} {Coordinate} {Status}";
        }
    }
}
