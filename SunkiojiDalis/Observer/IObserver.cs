namespace SignalRWebPack
{
    public interface IObserver
    {
        void Update(string message);
        void Notify();
    }
}
