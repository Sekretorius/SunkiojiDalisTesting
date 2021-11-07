namespace SignalRWebPack
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}