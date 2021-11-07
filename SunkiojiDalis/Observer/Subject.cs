using System.Collections.Generic;

namespace SignalRWebPack
{
    public class Subject
    {
        private List<IObserver> observers = new List<IObserver>();

        private string msg;
        public void Attatch(IObserver observer) 
        {
            observers.Add(observer);
        }
        public void Deattach(IObserver observer) 
        {
            observers.Remove(observer);
        }
        public void NotifyAll() 
        {
            foreach (var observer in observers)
                observer.Update(msg);
        }
        public virtual void ReceiveFromClient(string msg) 
        {
            this.msg = msg;
            NotifyAll();
        }
    }
}
