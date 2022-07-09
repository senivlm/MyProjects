namespace CassApp.Data
{
    public class Client : Person
    {
        public Guid Id { get; }
        protected int timeService;
        //cтруктуру передаємо по значенню
        protected Coordinate? coordinate { get; }
        protected Status? status;

        public Client(string name, int age, Guid id, int timeService, Coordinate? coordinate, Status? status) : base(name, age)
        {
            Id = id;
            this.timeService = timeService;
            this.coordinate = coordinate;
            this.status = status;
        }

        public int TimeService
        {
            get => timeService;
            set
            {
                timeService = value;
            }
        }
        public Status? Status { get => status; }
        public override string ToString()
        {
            return $"[{status}] - {name} {age} {coordinate} {timeService}";
        }
    }
}
