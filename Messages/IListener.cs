namespace Messages
{
    public interface IListener
    {

    }

    public interface IListener<T> : IListener where T : IUiBusEvent
    {
        void Handle(T theEvent);
    }
}