using Messages.Client;
using Microsoft.AspNetCore.Components;
using Web.Shared.Notifications;

namespace Web.Client.Components
{
    public partial class CounterComponent : UpdateIndicatorBaseComponent, IListener<CounterIncrementedNotification>
    {
        [Inject]
        private IUIBus? UIBus { get; set; }
        private int currentCount;
        protected override int DelayMS { get; } = 100;

        protected override void OnInitialized()
        {
            UIBus?.Register(this);
            base.OnInitialized();
        }
        public void Handle(CounterIncrementedNotification theEvent)
        {
            this.currentCount = theEvent.Count;
            base.Indicate();
        }

        public void Dispose()
        {
            UIBus?.UnRegister(this);
        }
    }
}
