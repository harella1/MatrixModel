namespace DesignPatterns.Observer
{
    public interface IObservable<out TMessage>
    {
        void Subscribe(IObserver<TMessage> observer);
        void Unsubscribe(IObserver<TMessage> observer);
    }
}