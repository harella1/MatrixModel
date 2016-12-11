using System.Collections.Generic;

namespace DesignPatterns.Observer
{
    public class Observable<TMessage> : IObservable<TMessage>
    {
        private readonly HashSet<IObserver<TMessage>> m_Observers;

        protected Observable()
        {
            m_Observers = new HashSet<IObserver<TMessage>>();
        }

        public void Subscribe(IObserver<TMessage> observer)
        {
            bool isOk = m_Observers.Add(observer);
            if (!isOk) throw new ObserverSubscribtionException("Can not subscribe twice.");
        }

        public void Unsubscribe(IObserver<TMessage> observer)
        {
            bool isOk = m_Observers.Remove(observer);
            if (!isOk) throw new ObserverSubscribtionException("Already usubscribed or never subscribed.");
        }

        protected void NotifyObservers(TMessage message)
        {
            foreach (var observer in m_Observers)
            {
                observer.OnNotified(message);
            }
        }
    }
}