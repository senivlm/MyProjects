namespace CassApp.Interfaces
{
    public interface ITerminal
    {
        public int Number { get; }
        public Coordinate Cordinate { get; }
        public event Action<ITerminal> IsEnabledEvent;
        public event Action<ITerminal> IsDisabledEvent;
        public string ToService(IClient client);
    }
}
