namespace CassApp.Interfaces
{
    public interface IClient
    {
        public Guid Id { get; }
        public int TimeService { get; }
        public Coordinate Coordinate { get; }
        public Status? Status { get; }
        public string ToString();
    }
}
