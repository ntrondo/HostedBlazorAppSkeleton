namespace Messages.Client
{
    public interface IListener:IDisposable
    {

    }

    public interface IListener<T> : IListener where T : IUiBusEvent
    {
        void Handle(T theEvent);
    }
}