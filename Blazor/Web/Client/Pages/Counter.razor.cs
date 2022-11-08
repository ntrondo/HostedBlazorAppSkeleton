using Messages.Client;
using Messages.ClientServer;
using Microsoft.AspNetCore.Components;
using Web.Shared.Notifications;
using Web.Shared.Queries;

namespace Web.Client.Pages
{
    public partial class Counter:ComponentBase
    {
        [Inject]
        private IAPIBus? Bus { get; set; }
        [Inject]
        private IUIBus? UIBus { get; set; }
        private int currentCount = 0;
        private string returnValue = "";

        private async void IncrementCount()
        {
            if (Bus == null)
                return;
            UIBus?.Notify(new CounterIncrementingNotification());
            currentCount++;
            var newCount = await Bus.Send(new CounterQuery(currentCount));
            returnValue = $"{newCount.NewCount} from server process '{newCount.ServerProcessName}'";
            StateHasChanged();
            UIBus?.Notify(new CounterIncrementedNotification());
        }

    }
}
