namespace DesignPatterns.Observer
{
    public interface IObserver<in TMessage>
    {
        void OnNotified(TMessage message);
    }
}