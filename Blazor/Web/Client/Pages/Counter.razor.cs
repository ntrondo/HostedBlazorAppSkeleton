using Messages.Client;
using Microsoft.AspNetCore.Components;
using Web.Shared.Notifications;

namespace Web.Client.Pages
{
    public partial class Counter:ComponentBase
    {
        [Inject]
        private IUIBus? UIBus { get; set; }
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
            UIBus?.Notify(new CounterIncrementedNotification(currentCount));            
        }
    }
}
