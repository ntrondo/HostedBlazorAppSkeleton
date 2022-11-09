using Messages.Client;

namespace Web.Shared.Notifications
{
    public class CounterIncrementedNotification : IUiBusEvent
    {
        public int Count { get; }
        public CounterIncrementedNotification(int count)
        {
            this.Count = count;
        }
    }
}
