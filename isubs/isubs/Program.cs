using System;
using System.Collections.Generic;

namespace isubs
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new Publisher();
        }
    }
    public interface ISubscriber
    {
        void Update();
    }
    public class ConcreteSubscriber : ISubscriber
    {
        private Publisher _publisher;
        public ConcreteSubscriber(Publisher publisher)
        {
            _publisher = publisher;
        }
    }
    public class Publisher
    {
        public IList<ISubscriber> _subscribers { get; } = new List<ISubscriber>();
        public string MainState { get; private set; }
        public void Subscribe(ISubscriber subscriber)
        {
            if(_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }
        public void UnSubscribe(ISubscriber subscriber)
        {
            if(_subscribers.Contains(subscriber))
            {
                _subscribers.Remove(subscriber);
            }
        }
        public void NotifyAll()
        {
            foreach(var s in _subscribers)
            {
                s.Update();
            }
        }
        public void MainBusinessLogic()
        {
            while(true)
            {
                MainState = Guid.NewGuid().ToString();
                NotifyAll();
            }
        }
    }
}
